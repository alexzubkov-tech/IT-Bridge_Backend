namespace NotificationBotApp.Domain.Entities;

public class UserChatBinding
{
    public int Id { get; set; }
    public long ChatId { get; set; }
    public string? Username { get; set; }
    public int UserProfileId { get; set; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
}