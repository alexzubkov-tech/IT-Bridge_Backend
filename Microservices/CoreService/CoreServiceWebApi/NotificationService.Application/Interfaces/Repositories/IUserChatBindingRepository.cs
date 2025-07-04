using NotificationBotApp.Domain.Entities;

namespace NotificationService.Application.Interfaces.Repositories;

public interface IUserChatBindingRepository
{
    Task AddAsync(UserChatBinding binding);
    Task<UserChatBinding?> GetByUserProfileId(int userProfileId);
}