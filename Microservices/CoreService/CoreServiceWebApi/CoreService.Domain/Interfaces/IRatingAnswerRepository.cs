using CoreService.Domain.Entities;

namespace CoreService.Domain.Interfaces
{
    public interface IRatingAnswerRepository
    {
        Task<bool> HasUserAlreadyRatedAnswer(int userProfileId, int answerId, CancellationToken ct);
        Task<RatingAnswer> GetByIdAsync(int id);
        Task<IEnumerable<RatingAnswer>> GetAllAsync();
        Task<IEnumerable<RatingAnswer>> GetAllToAnswerAsync(int id);
        Task<IEnumerable<RatingAnswer>> GetAllRatingAnswerToUserProfileAsync(int id);
        Task<int> CreateAsync(RatingAnswer ratingAnswer);
        Task<bool> UpdateAsync(RatingAnswer ratingAnswer);
        Task<bool> DeleteAsync(int id);
    }
}