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

// ����������� RabbitMQ
builder.Services.RegisterRabbit(configuration);

// ����������� IEventBus
builder.Services.AddSingleton<IEventBus, RabbitMQBus>();

// ����������� ����������� �������
builder.Services.AddTransient<QuestionCreatedEventHandler>();

builder.Services.AddSingleton<IQuestionRepository, InMemoryQuestionRepository>();

var app = builder.Build();

// �������� �� �������
var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<QuestionCreatedNotificationEvent, QuestionCreatedEventHandler>();

app.UseHttpsRedirection();
app.Run();