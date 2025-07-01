using CoreService.Domain.Interfaces;
using CoreService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreService.Infrastructure.Repositories
{
    public class CommentAnswerRepository : ICommentAnswerRepository
    {
        private readonly CoreServiceDbContext _context;

        public CommentAnswerRepository(CoreServiceDbContext context)
        {
            _context = context;
        }

        public async Task<CommentAnswer> GetByIdAsync(int id)
        {
            return await _context.CommentAnswers
                .Include(c => c.UserProfile)
                .Include(c => c.Answer)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<CommentAnswer>> GetAllAsync()
        {
            return await _context.CommentAnswers
                .Include(c => c.UserProfile)
                .Include(c => c.Answer)
                .ToListAsync();
        }

        public async Task<IEnumerable<CommentAnswer>> GetAllToAnswerAsync(int id)
        {
            return await _context.CommentAnswers
                .Where(cq => cq.AnswerId == id)
                .Include(c => c.UserProfile)
                .Include(c => c.Answer)
                .ToListAsync();
        }

        public async Task<int> CreateAsync(CommentAnswer comment)
        {
            await _context.CommentAnswers.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment.Id;
        }

        public async Task<bool> UpdateAsync(CommentAnswer comment)
        {
            _context.CommentAnswers.Update(comment);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var comment = await _context.CommentAnswers.FindAsync(id);
            if (comment == null) return false;

            _context.CommentAnswers.Remove(comment);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }
    }
}