namespace NotificationBotApp.Infrastructure.Bot
{
    public interface INotifyService
    {
        Task NotifyChatsAsync(List<long> chatIds, string message, CancellationToken ct = default);
    }
}