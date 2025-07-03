using BuildingBlock.Events;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBusRabbitMQ;
using BuildingBlocks.Events;
using Microsoft.Extensions.Configuration;
using Notification;
using NotificationService.Application.Interfaces.Repositories;
using NotificationService.EventHandlers;
using NotificationService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Регистрация RabbitMQ
builder.Services.RegisterRabbit(configuration);

// Регистрация IEventBus
builder.Services.AddSingleton<IEventBus, RabbitMQBus>();

// Регистрация обработчика события
builder.Services.AddTransient<QuestionCreatedEventHandler>();

builder.Services.AddSingleton<IQuestionRepository, InMemoryQuestionRepository>();

var app = builder.Build();

// Подписка на событие
var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<QuestionCreatedNotificationEvent, QuestionCreatedEventHandler>();

app.UseHttpsRedirection();
app.Run();