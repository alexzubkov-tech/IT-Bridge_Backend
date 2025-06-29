using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoreService.Infrastructure.Repositories
{
    public class CommentQuestionRepository : ICommentQuestionRepository
    {
        private readonly CoreServiceDbContext _context;

        public CommentQuestionRepository(CoreServiceDbContext context)
        {
            _context = context;
        }

        public async Task<CommentQuestion> GetByIdAsync(int id)
        {
            return await _context.CommentQuestions
                .Include(c => c.UserProfile)
                .Include(c => c.Question)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<CommentQuestion>> GetAllAsync()
        {
            return await _context.CommentQuestions
                .Include(c => c.UserProfile)
                .Include(c => c.Question)
                .ToListAsync();
        }

        public async Task<int> CreateAsync(CommentQuestion comment)
        {
            await _context.CommentQuestions.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment.Id;
        }

        public async Task<bool> UpdateAsync(CommentQuestion comment)
        {
            _context.CommentQuestions.Update(comment);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var comment = await _context.CommentQuestions.FindAsync(id);
            if (comment == null) return false;

            _context.CommentQuestions.Remove(comment);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }
    }
}