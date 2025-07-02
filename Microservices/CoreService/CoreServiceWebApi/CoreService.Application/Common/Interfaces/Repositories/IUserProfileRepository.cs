using CoreService.Application.Common.Interfaces.Repositories;
using CoreService.Domain.Entities;


namespace CoreService.Application.Common.Interfaces.Repositories
{
    public interface IUserProfileRepository
    {
        Task<UserProfile> GetByIdAsync(int id);
        Task<UserProfile> GetByUserIdAsync(string userId);
        Task<IEnumerable<UserProfile>> GetAllAsync();
        Task<int> CreateAsync(UserProfile profile);
        Task<bool> UpdateAsync(UserProfile profile);
        Task<bool> DeleteAsync(int id);
    }
}
