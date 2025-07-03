using CoreService.Domain.Entities;

namespace CoreService.Domain.Interfaces
{
    public interface IRatingQuestionRepository
    {
        Task<RatingQuestion> GetByIdAsync(int id);
        Task<IEnumerable<RatingQuestion>> GetAllAsync();
        Task<IEnumerable<RatingQuestion>> GetAllWithDetailsAsync();
        Task<IEnumerable<RatingQuestion>> GetAllToQuestionAsync(int id);
        Task<IEnumerable<RatingQuestion>> GetAllRatingQuestionToQuestionAsync(int id);
        Task<int> CreateAsync(RatingQuestion rating);
        Task<bool> UpdateAsync(RatingQuestion rating);
        Task<bool> DeleteAsync(int id);
    }
}