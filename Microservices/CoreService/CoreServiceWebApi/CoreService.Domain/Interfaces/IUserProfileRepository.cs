
using CoreService.Domain.Entities;

namespace CoreService.Domain.Interfaces
{
        public interface IUserProfileRepository
        {
            Task<UserProfile> GetByIdAsync(int id);
            Task<UserProfile> GetByUserIdAsync(string userId);
            Task<IEnumerable<UserProfile>> GetAllAsync();
            Task<IEnumerable<UserProfile>> GetByCategoryIdsAsync(IEnumerable<int> categoryIds);
            Task<int> CreateAsync(UserProfile profile);
            Task<bool> UpdateAsync(UserProfile profile);
            Task<bool> DeleteAsync(int id);
            Task<string> GetCategoryNameByUserProfileIdAsync(int userProfileId);
    }
}
