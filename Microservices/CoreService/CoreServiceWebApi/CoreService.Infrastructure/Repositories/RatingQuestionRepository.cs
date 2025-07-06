using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoreService.Infrastructure.Repositories
{
    public class RatingQuestionRepository : IRatingQuestionRepository
    {
        private readonly CoreServiceDbContext _context;

        public RatingQuestionRepository(CoreServiceDbContext context)
        {
            _context = context;
        }

        public async Task<bool> HasUserAlreadyRatedQuestion(int userProfileId, int questionId, CancellationToken ct)
        {
            return await _context.RatingQuestions
                .AnyAsync(rq => rq.UserProfileId == userProfileId && rq.QuestionId == questionId, ct);
        }

        public async Task<RatingQuestion> GetByIdAsync(int id)
        {
            return await _context.RatingQuestions
                .Include(r => r.UserProfile)
                .Include(r => r.Question)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<RatingQuestion>> GetAllAsync()
        {
            return await _context.RatingQuestions
                .Include(r => r.UserProfile)
                .Include(r => r.Question)
                .ToListAsync();
        }

        public async Task<IEnumerable<RatingQuestion>> GetAllWithDetailsAsync()
        {
            return await _context.RatingQuestions
                .Include(r => r.Question)
                    .ThenInclude(q => q.UserProfile)
                .Include(r => r.Question)
                    .ThenInclude(q => q.QuestionTags)
                        .ThenInclude(qt => qt.Tag)
                .Include(r => r.Question)
                    .ThenInclude(q => q.QuestionCategories)
                        .ThenInclude(qc => qc.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<RatingQuestion>> GetAllToQuestionAsync(int id)
        {
            return await _context.RatingQuestions
                .Where(rq => rq.QuestionId == id)
                .Include(r => r.UserProfile)
                .Include(r => r.Question)
                .ToListAsync();
        }

        public async Task<IEnumerable<RatingQuestion>> GetAllRatingQuestionToQuestionAsync(int id)
        {
            return await _context.RatingQuestions
                .Where(rq => rq.QuestionId == id)
                .ToListAsync();
        }

        public async Task<int> CreateAsync(RatingQuestion rating)
        {
            await _context.RatingQuestions.AddAsync(rating);
            await _context.SaveChangesAsync();
            return rating.Id;
        }

        public async Task<bool> UpdateAsync(RatingQuestion rating)
        {
            _context.RatingQuestions.Update(rating);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var rating = await _context.RatingQuestions.FindAsync(id);
            if (rating == null) return false;

            _context.RatingQuestions.Remove(rating);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }
    }
}