using CoreService.Domain.Entities;

namespace CoreService.Domain.Interfaces
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