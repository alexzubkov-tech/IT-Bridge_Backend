using CoreService.Domain.Interfaces;
using CoreService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreService.Infrastructure.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly CoreServiceDbContext _context;

        public AnswerRepository(CoreServiceDbContext context)
        {
            _context = context;
        }

        public async Task<Answer> GetByIdAsync(int id)
        {
            return await _context.Answers
                .Include(a => a.UserProfile)
                .Include(a => a.Question)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Answer>> GetAllAsync()
        {
            return await _context.Answers
                .Include(a => a.UserProfile)
                .Include(a => a.Question)
                .ToListAsync();
        }
        public async Task<IEnumerable<Answer>> GetByQuestionIdAsync(int questionId)
        {
            return await _context.Answers
                .Include(a => a.UserProfile)
                .Where(a => a.QuestionId == questionId)
                .ToListAsync();
        }

        public async Task<int> CreateAsync(Answer answer)
        {
            await _context.Answers.AddAsync(answer);
            await _context.SaveChangesAsync();
            return answer.Id;
        }

        public async Task<bool> UpdateAsync(Answer answer)
        {
            _context.Answers.Update(answer);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null) return false;

            _context.Answers.Remove(answer);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }
    }
}