using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreService.Infrastructure.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly CoreServiceDbContext _context;

        public QuestionRepository(CoreServiceDbContext context)
        {
            _context = context;
        }

        public async Task<Question?> GetByIdAsync(int id, CancellationToken ct)
        {
            return await _context.Questions
                .Include(q => q.UserProfile)
                    .ThenInclude(u => u.User)
                .Include(q => q.Answers)
                    .ThenInclude(a => a.UserProfile)
                .Include(q => q.CommentQuestions)
                    .ThenInclude(cq => cq.UserProfile)
                .Include(q => q.RatingQuestions)
                    .ThenInclude(rq => rq.UserProfile)
                .Include(q => q.QuestionTags)
                    .ThenInclude(qt => qt.Tag)
                .Include(q => q.QuestionCategories)
                    .ThenInclude(qc => qc.Category)
                .FirstOrDefaultAsync(q => q.Id == id, ct);
        }

        public async Task<IEnumerable<Question>> GetAllAsync(CancellationToken ct)
        {
            return await _context.Questions
                .Include(q => q.QuestionTags)
                    .ThenInclude(qt => qt.Tag)
                .Include(q => q.QuestionCategories)
                    .ThenInclude(qc => qc.Category)
                .ToListAsync(ct);
        }

        public async Task<int> CreateAsync(Question question, CancellationToken ct)
        {
            await _context.Questions.AddAsync(question, ct);
            await _context.SaveChangesAsync(ct);
            return question.Id;
        }

        public async Task<bool> UpdateAsync(Question question, CancellationToken ct)
        {
            _context.Questions.Update(question);
            var rowsAffected = await _context.SaveChangesAsync(ct);
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {
            var question = await _context.Questions.FindAsync(new object[] { id }, ct);
            if (question == null) return false;

            _context.Questions.Remove(question);
            var rowsAffected = await _context.SaveChangesAsync(ct);
            return rowsAffected > 0;
        }


        public async Task<List<string>> GetSpecializationNamesByCategoryIds(List<int> categoryIds, CancellationToken ct)
        {
            return await _context.Categories
                .Where(c => categoryIds.Contains(c.Id))
                .Select(c => c.Name)
                .ToListAsync(ct);
        }
    }
}