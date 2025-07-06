using CoreService.Domain.Entities;

namespace CoreService.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> CategoryExists(int categoryId);
        Task<Category> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<int> CreateAsync(Category category);
        Task<bool> UpdateAsync(Category category);
        Task<bool> DeleteAsync(int id);
    }
}