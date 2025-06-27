
using CoreService.Domain.Entities;

namespace CoreService.Domain.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<UserProfile> GetByIdAsync(int id);
        Task<IEnumerable<UserProfile>> GetAllAsync();
        Task<int> CreateAsync(UserProfile profile);
        Task<bool> UpdateAsync(UserProfile profile);
        Task<bool> DeleteAsync(int id);
    }
}
