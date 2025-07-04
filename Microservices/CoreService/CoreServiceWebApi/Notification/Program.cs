using BuildingBlock.Events;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBusRabbitMQ;
using BuildingBlocks.Events;
using Microsoft.EntityFrameworkCore;
using Notification;
using NotificationBotApp.Application.EventHandlers;
using NotificationBotApp.Infrastructure;
using NotificationBotApp.Infrastructure.Bot;
using NotificationBotApp.Infrastructure.Repositories;
using NotificationService;
using NotificationService.Application.ChatBindin.Mapper;
using NotificationService.Application.Common.Interfaces;
using NotificationService.Application.Interfaces.Repositories;
using NotificationService.EventHandlers;
using NotificationService.Infrastructure;
using NotificationService.Infrastructure.Repositories;
using System;
using Telegram.Bot;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Регистрация RabbitMQ
builder.Services.RegisterRabbit(configuration);

// Регистрация IEventBus
builder.Services.AddSingleton<IEventBus, RabbitMQBus>();

// Добавляем Telegram Bot Client
builder.Services.AddSingleton<ITelegramBotClient>(sp =>
{
    var token = builder.Configuration["Telegram:BotToken"];
    return new TelegramBotClient(token);
});

// Добавляем EF Core
builder.Services.AddDbContext<INotificationServiceDbContext, NotificationServiceDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));



// MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(BindTelegramChatCommand).Assembly);
});

// Репозитории
builder.Services.AddScoped<IUserChatBindingRepository, UserChatBindingRepository>();

builder.Services.AddScoped<INotifyService, NotifyService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<NotifyService>();

// Фоновый бот
builder.Services.AddHostedService<BotBackgroundService>();

builder.Services.AddAutoMapper(typeof(ChatBindingMapper));

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