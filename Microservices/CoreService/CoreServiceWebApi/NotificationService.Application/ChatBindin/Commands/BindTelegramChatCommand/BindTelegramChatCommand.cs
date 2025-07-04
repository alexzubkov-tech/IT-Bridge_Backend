using MediatR;

namespace NotificationBotApp.Application.Commands;

public class BindTelegramChatCommand : IRequest<bool>
{
    public long ChatId { get; set; }
    public string? Username { get; set; }
    public int UserProfileId { get; set; }
}