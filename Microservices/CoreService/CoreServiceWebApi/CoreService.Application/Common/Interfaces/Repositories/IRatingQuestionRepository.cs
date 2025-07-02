using CoreService.Application.Common.Interfaces.Repositories;
using CoreService.Domain.Entities;


namespace CoreService.Application.Common.Interfaces.Repositories
{
    public interface IRatingQuestionRepository
    {
        Task<RatingQuestion> GetByIdAsync(int id);
        Task<IEnumerable<RatingQuestion>> GetAllAsync();
        Task<int> CreateAsync(RatingQuestion rating);
        Task<bool> UpdateAsync(RatingQuestion rating);
        Task<bool> DeleteAsync(int id);
    }
}