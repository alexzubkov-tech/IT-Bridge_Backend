using MediatR;

public class BindTelegramChatCommand : IRequest<BindTelegramChatResult>
{
    public long ChatId { get; set; }
    public string? Username { get; set; }
    public int UserProfileId { get; set; }
    public int CategoryId { get; set; }
}

public class BindTelegramChatResult
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
}