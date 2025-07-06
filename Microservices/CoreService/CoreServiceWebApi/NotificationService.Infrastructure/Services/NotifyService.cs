using NotificationBotApp.Infrastructure.Bot;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

public class NotifyService : INotifyService
{
    private readonly ITelegramBotClient _botClient;

    public NotifyService(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    // Измени название метода и тип параметра
    public async Task NotifyChatsAsync(List<long> chatIds, string message, CancellationToken ct = default)
    {
        foreach (var chatId in chatIds)
        {
            try
            {
                await _botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: message,
                    parseMode: ParseMode.Html,
                    cancellationToken: ct);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отправке сообщения в чат {chatId}: {ex.Message}");
            }
        }
    }
}