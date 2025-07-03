using System;
using System.Collections.Generic;
using BuildingBlock.Events;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBusRabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

class Program
{
    static void Main()
    {
        // 1. Создаем конфигурацию для RabbitMQ
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string>
            {
                ["EventBusRabbitMQ:EventBusConnection"] = "localhost",
                ["EventBusRabbitMQ:EventBusPort"] = "5672",
                ["EventBusRabbitMQ:EventBusUserName"] = "guest",
                ["EventBusRabbitMQ:EventBusPassword"] = "guest"
            })
            .Build();

        // 2. Создаем экземпляр RabbitMQBus с заглушкой IServiceScopeFactory
        var eventBus = new RabbitMQBus(new DummyScopeFactory(), config);

        // 3. Подписываемся на событие TestEvent
        eventBus.Subscribe<TestEvent, TestEventHandler>();

        Console.WriteLine("Сервис уведомлений запущен. Ожидание сообщений TestEvent...");
        Console.WriteLine("Нажмите Enter для выхода.");
        Console.ReadLine();
    }
}

// Обработчик события (вызывается через Consumer_Received)
public class TestEventHandler : IEventHandler<TestEvent>
{
    public Task Handle(TestEvent @event)
    {
        Console.WriteLine($"Получено сообщение: {@event.message}");
        return Task.CompletedTask;
    }
}

// Заглушка для IServiceScopeFactory
public class DummyScopeFactory : IServiceScopeFactory
{
    public IServiceScope CreateScope() => new DummyScope();
}

public class DummyScope : IServiceScope
{
    public IServiceProvider ServiceProvider => new DummyServiceProvider();
    public void Dispose() { }
}

public class DummyServiceProvider : IServiceProvider
{
    public object GetService(Type serviceType) => null;
}