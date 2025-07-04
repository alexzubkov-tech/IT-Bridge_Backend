using MediatR;
using NotificationBotApp.Models.DTOs;

namespace NotificationBotApp.Application.Queries;

public class GetChatByUserProfileQuery : IRequest<ChatBindingDto?>
{
    public int UserProfileId { get; }

    public GetChatByUserProfileQuery(int userProfileId)
        => UserProfileId = userProfileId;
}