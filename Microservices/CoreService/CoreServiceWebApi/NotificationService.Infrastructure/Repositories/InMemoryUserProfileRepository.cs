using NotificationService.Application.Interfaces.Repositories;
using NotificationService.Domain.Entities;

namespace NotificationService.Infrastructure.Repositories
{
    public class InMemoryUserProfileRepository : IUserProfileRepository
    {
        private readonly List<UserProfile> _experts = new();

        public async Task<UserProfile> GetByUserProfileIdAsync(int userProfileId)
        {
            return await Task.FromResult(_experts.FirstOrDefault(e => e.UserProfileId == userProfileId));
        }

        public async Task CreateAsync(UserProfile expert)
        {
            _experts.Add(expert);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(UserProfile expert)
        {
            var existing = _experts.FirstOrDefault(e => e.UserProfileId == expert.UserProfileId);
            if (existing != null)
            {
                existing.ChatId = expert.ChatId;
                existing.CategoryName = expert.CategoryName;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int userProfileId)
        {
            var existing = _experts.FirstOrDefault(e => e.UserProfileId == userProfileId);
            if (existing != null)
            {
                _experts.Remove(existing);
            }
            await Task.CompletedTask;
        }
    }
}
