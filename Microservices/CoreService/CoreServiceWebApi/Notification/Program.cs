using BuildingBlock.Events;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBusRabbitMQ;
using Microsoft.Extensions.Configuration;
using NotificationService.EventHandlers;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Регистрация RabbitMQ
builder.Services.RegisterRabbit(configuration);

// Регистрация IEventBus
builder.Services.AddSingleton<IEventBus, RabbitMQBus>();

// Регистрация обработчика события
builder.Services.AddTransient<TestEventHandler>();

var app = builder.Build();

// Подписка на событие
var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<TestEvent, TestEventHandler>();

app.UseHttpsRedirection();
app.Run();