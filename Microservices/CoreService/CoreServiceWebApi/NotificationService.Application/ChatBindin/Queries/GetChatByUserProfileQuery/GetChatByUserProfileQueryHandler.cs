using MediatR;
using NotificationBotApp.Models.DTOs;
using NotificationService.Application.Interfaces.Repositories;

namespace NotificationBotApp.Application.Queries;

public class GetChatByUserProfileQueryHandler : IRequestHandler<GetChatByUserProfileQuery, ChatBindingDto?>
{
    private readonly IUserChatBindingRepository _repository;

    public GetChatByUserProfileQueryHandler(IUserChatBindingRepository repository)
        => _repository = repository;

    public async Task<ChatBindingDto?> Handle(GetChatByUserProfileQuery request, CancellationToken ct)
    {
        var binding = await _repository.GetByUserProfileId(request.UserProfileId);
        return binding is null ? null : new ChatBindingDto
        {
            ChatId = binding.ChatId,
            Username = binding.Username,
            UserProfileId = binding.UserProfileId
        };
    }
}