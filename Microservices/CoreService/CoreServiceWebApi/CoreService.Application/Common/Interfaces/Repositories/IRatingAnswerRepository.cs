using CoreService.Application.Common.Interfaces.Repositories;
using CoreService.Domain.Entities;


namespace CoreService.Application.Common.Interfaces.Repositories
{
    public interface IRatingAnswerRepository
    {
        Task<RatingAnswer> GetByIdAsync(int id);
        Task<IEnumerable<RatingAnswer>> GetAllAsync();
        Task<int> CreateAsync(RatingAnswer ratingAnswer);
        Task<bool> UpdateAsync(RatingAnswer ratingAnswer);
        Task<bool> DeleteAsync(int id);
    }
}