using NotificationBotApp.Domain.Entities;

namespace NotificationService.Application.Interfaces.Repositories;

public interface IUserChatBindingRepository
{
    Task AddAsync(UserChatBinding binding);
    Task<bool> ExistsByUserProfileId(int userProfileId, CancellationToken ct);
    Task<UserChatBinding?> GetByUserProfileId(int userProfileId);
    Task<List<long>> GetChatIdsByCategoryIds(List<int> categoryIds, CancellationToken ct);
}