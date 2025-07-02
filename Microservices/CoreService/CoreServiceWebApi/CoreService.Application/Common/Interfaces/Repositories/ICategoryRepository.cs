using CoreService.Application.Common.Interfaces.Repositories;
using CoreService.Domain.Entities;

namespace CoreService.Application.Common.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<int> CreateAsync(Category category);
        Task<bool> UpdateAsync(Category category);
        Task<bool> DeleteAsync(int id);
    }
}