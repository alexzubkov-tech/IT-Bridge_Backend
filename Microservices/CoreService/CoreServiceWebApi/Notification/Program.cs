using BuildingBlock.Events;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBusRabbitMQ;
using BuildingBlocks.Events;
using Microsoft.Extensions.Configuration;
using Notification;
using NotificationService;
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
builder.Services.AddTransient<UserProfileUpdatedNotificationEventHandler>();

builder.Services.AddSingleton<IQuestionRepository, InMemoryQuestionRepository>();
builder.Services.AddSingleton<IUserProfileRepository, InMemoryUserProfileRepository>();

var app = builder.Build();

// Подписка на событие
using (var scope = app.Services.CreateScope())
{
    EventBusExtension.SubscribeToEvents(scope.ServiceProvider);
}

app.UseHttpsRedirection();
app.Run();