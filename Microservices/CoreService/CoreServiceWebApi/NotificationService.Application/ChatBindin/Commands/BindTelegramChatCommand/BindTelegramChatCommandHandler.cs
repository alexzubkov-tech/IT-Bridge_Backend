using MediatR;
using NotificationBotApp.Domain.Entities;
using NotificationService.Application.Interfaces.Repositories;

namespace NotificationBotApp.Application.Commands;

public class BindTelegramChatCommandHandler : IRequestHandler<BindTelegramChatCommand, bool>
{
    private readonly IUserChatBindingRepository _repository;

    public BindTelegramChatCommandHandler(IUserChatBindingRepository repository)
        => _repository = repository;

    public async Task<bool> Handle(BindTelegramChatCommand request, CancellationToken ct)
    {
        var binding = new UserChatBinding
        {
            ChatId = request.ChatId,
            Username = request.Username,
            UserProfileId = request.UserProfileId,
            CategoryId = request.CategoryId,
        };

        await _repository.AddAsync(binding);
        return true;
    }
}