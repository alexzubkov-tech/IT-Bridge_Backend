using BuildingBlocks.EventBus.Abstractions;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace BuildingBlocks.EventBusRabbitMQ;

public class RabbitMQBusPublisher : IEventBusPublisher
{
    private readonly IConnection _connection;
    private readonly IModel _channel;


    public RabbitMQBusPublisher(IConnection connection)
    {
        _connection = connection;
        _channel = connection.CreateModel();
    }

    public void Publish<T>(T @event) where T : IEvent
    {
        var eventName = @event.GetType().Name;
        _channel.QueueDeclare(eventName, false, false, false, null);
        var message = JsonConvert.SerializeObject(@event);
        var body = Encoding.UTF8.GetBytes(message);
        _channel.BasicPublish("", eventName, null, body);
    }
}