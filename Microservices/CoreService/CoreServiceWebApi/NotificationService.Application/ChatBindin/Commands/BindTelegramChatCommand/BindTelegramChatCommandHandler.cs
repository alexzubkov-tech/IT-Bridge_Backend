using MediatR;
using NotificationBotApp.Domain.Entities;
using NotificationService.Application.Interfaces.Repositories;

public class BindTelegramChatCommandHandler
    : IRequestHandler<BindTelegramChatCommand, BindTelegramChatResult>
{
    private readonly IUserChatBindingRepository _repository;

    public BindTelegramChatCommandHandler(IUserChatBindingRepository repository)
        => _repository = repository;

    public async Task<BindTelegramChatResult> Handle(
        BindTelegramChatCommand request,
        CancellationToken ct)
    {
        if (await _repository.ExistsByUserProfileId(request.UserProfileId, ct))
        {
            return new BindTelegramChatResult
            {
                Success = false,
                Message = "Вы уже зарегистрированы."
            };
        }

        var binding = new UserChatBinding
        {
            ChatId = request.ChatId,
            Username = request.Username,
            UserProfileId = request.UserProfileId,
            CategoryId = request.CategoryId
        };

        await _repository.AddAsync(binding);

        return new BindTelegramChatResult
        {
            Success = true,
            Message = $"Привязано к профилю ID={request.UserProfileId}, категория {request.CategoryId}"
        };
    }
}