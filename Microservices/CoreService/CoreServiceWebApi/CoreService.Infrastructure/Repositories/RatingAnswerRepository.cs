using CoreService.Domain.Interfaces;
using CoreService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreService.Infrastructure.Repositories
{
    public class RatingAnswerRepository : IRatingAnswerRepository
    {
        private readonly CoreServiceDbContext _context;

        public RatingAnswerRepository(CoreServiceDbContext context)
        {
            _context = context;
        }

        public async Task<bool> HasUserAlreadyRatedAnswer(int userProfileId, int answerId, CancellationToken ct)
        {
            return await _context.RatingAnswers
                .AnyAsync(r => r.UserProfileId == userProfileId && r.AnswerId == answerId, ct);
        }
        public async Task<RatingAnswer> GetByIdAsync(int id)
        {
            return await _context.RatingAnswers
                .Include(r => r.UserProfile)
                .Include(r => r.Answer)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<RatingAnswer>> GetAllAsync()
        {
            return await _context.RatingAnswers
                .Include(r => r.UserProfile)
                .Include(r => r.Answer)
                .ToListAsync();
        }

        public async Task<IEnumerable<RatingAnswer>> GetAllToAnswerAsync(int id)
        {
            return await _context.RatingAnswers
                .Where(rq => rq.AnswerId == id)
                .Include(r => r.UserProfile)
                .Include(r => r.Answer)
                .ToListAsync();
        }

        public async Task<IEnumerable<RatingAnswer>> GetAllRatingAnswerToUserProfileAsync(int id)
        {
            return await _context.RatingAnswers
                .Where(rq => rq.Answer.UserProfileId == id)
                .ToListAsync();
        }

        public async Task<int> CreateAsync(RatingAnswer rating)
        {
            await _context.RatingAnswers.AddAsync(rating);
            await _context.SaveChangesAsync();
            return rating.Id;
        }

        public async Task<bool> UpdateAsync(RatingAnswer rating)
        {
            _context.RatingAnswers.Update(rating);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var rating = await _context.RatingAnswers.FindAsync(id);
            if (rating == null) return false;

            _context.RatingAnswers.Remove(rating);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }
    }
}