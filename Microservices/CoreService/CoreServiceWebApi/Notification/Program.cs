using BuildingBlock.Events;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBusRabbitMQ;
using Microsoft.Extensions.Configuration;
using NotificationService.EventHandlers;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// ����������� RabbitMQ
builder.Services.RegisterRabbit(configuration);

// ����������� IEventBus
builder.Services.AddSingleton<IEventBus, RabbitMQBus>();

// ����������� ����������� �������
builder.Services.AddTransient<TestEventHandler>();

var app = builder.Build();

// �������� �� �������
var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<TestEvent, TestEventHandler>();

app.UseHttpsRedirection();
app.Run();