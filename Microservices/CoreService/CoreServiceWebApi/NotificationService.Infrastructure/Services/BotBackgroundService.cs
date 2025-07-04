using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotificationBotApp.Application.Commands;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace NotificationBotApp.Infrastructure;

public class BotBackgroundService : BackgroundService
{
    private readonly ITelegramBotClient _botClient;
    private readonly IServiceProvider _serviceProvider;

    public BotBackgroundService(
        ITelegramBotClient botClient,
        IServiceProvider serviceProvider)
    {
        _botClient = botClient;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };

        _botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            errorHandler: HandlePollingErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: stoppingToken
        );

        var me = await _botClient.GetMeAsync(stoppingToken);
        Console.WriteLine($"Bot {me.Username} is running");

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken);
        }
    }

    private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken ct)
    {
        if (update.Message is not { } message || message.Text is not { } messageText)
            return;

        if (messageText.StartsWith("/start"))
        {
            var parts = messageText.Split(' ');
            if (parts.Length > 1)
            {
                // Парсим "123_456"
                var payload = parts[1].Split('_');
                if (payload.Length == 2 &&
                    int.TryParse(payload[0], out int userProfileId) &&
                    int.TryParse(payload[1], out int categoryId))
                {
                    using var scope = _serviceProvider.CreateScope();
                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                    var command = new BindTelegramChatCommand
                    {
                        ChatId = message.Chat.Id,
                        Username = message.Chat.Username,
                        UserProfileId = userProfileId,
                        CategoryId = categoryId
                    };

                    await mediator.Send(command, ct);

                    await botClient.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: $"✅ Привязано к профилю ID={userProfileId}, категория {categoryId}",
                        cancellationToken: ct);
                }
            }
        }
    }
    private Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken ct)
    {
        Console.WriteLine($"Ошибка: {exception.Message}");
        return Task.CompletedTask;
    }
}