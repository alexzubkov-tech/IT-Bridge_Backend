using System.Text;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBusRabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BuildingBlocks.EventBusRabbitMQ;

public class RabbitMQBus : IEventBus
{
    private readonly Dictionary<string, List<Type>> _handlers = new();
    private readonly List<Type> _eventTypes = new();
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ConnectionFactory _connectionFactory;

    public RabbitMQBus(IServiceScopeFactory serviceScopeFactory, IConfiguration configuration)
    {
        _serviceScopeFactory = serviceScopeFactory;
        string stringConnection = configuration["EventBusRabbitMQ:EventBusConnection"] ?? throw new ArgumentNullException("EventBusConnection");
        int port = int.Parse(configuration["EventBusRabbitMQ:EventBusPort"] ?? throw new ArgumentNullException("EventBusPort"));
        string username = configuration["EventBusRabbitMQ:EventBusUserName"] ?? throw new ArgumentNullException("EventBusUserName");
        string password = configuration["EventBusRabbitMQ:EventBusPassword"] ?? throw new ArgumentNullException("EventBusPassword");
        _connectionFactory = new ConnectionFactory()
        {
            HostName = stringConnection,
            Port = port,
            DispatchConsumersAsync = true,
            UserName = username,
            Password = password
        };
    }

    public RabbitMQBusPublisher CreatePublisher()
    {
        return new RabbitMQBusPublisher(_connectionFactory.CreateConnection());
    }

    public void Subscribe<T, TH>()
        where T : IEvent
        where TH : IEventHandler<T>
    {
        var eventName = typeof(T).Name;
        var handlerType = typeof(TH);

        if (!_eventTypes.Contains(typeof(T))) _eventTypes.Add(typeof(T));

        if (!_handlers.ContainsKey(eventName)) _handlers.Add(eventName, new List<Type>());

        if (_handlers[eventName].Any(s => s.GetType() == handlerType))
            throw new ArgumentException(
                $"Handler Type {handlerType.Name} already is registered for '{eventName}'", nameof(handlerType));

        _handlers[eventName].Add(handlerType);

        StartBasicConsume<T>();
    }

    private void StartBasicConsume<T>() where T : IEvent
    {
        var connection = _connectionFactory.CreateConnection();
        var channel = connection.CreateModel();

        var eventName = typeof(T).Name;

        channel.QueueDeclare(eventName, false, false, false, null);

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.Received += Consumer_Received;

        channel.BasicConsume(eventName, true, consumer);
    }

    private async Task Consumer_Received(object sender, BasicDeliverEventArgs e)
    {
        var eventName = e.RoutingKey;
        var message = Encoding.UTF8.GetString(e.Body.ToArray());

        try
        {
            await ProcessEvent(eventName, message).ConfigureAwait(false);
        }
        //TODO добавить логирование ошибки
        catch (Exception ex)
        {
        }
    }

    private async Task ProcessEvent(string eventName, string message)
    {
        if (_handlers.ContainsKey(eventName))
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var subscriptions = _handlers[eventName];
                foreach (var subscription in subscriptions)
                {
                    var handler = scope.ServiceProvider.GetService(subscription);
                    if (handler == null) continue;
                    var eventType = _eventTypes.SingleOrDefault(t => t.Name == eventName);
                    var @event = JsonConvert.DeserializeObject(message, eventType);
                    var conreteType = typeof(IEventHandler<>).MakeGenericType(eventType);
                    await (Task)conreteType.GetMethod("Handle").Invoke(handler, new object[] { @event });
                }
            }
    }
}