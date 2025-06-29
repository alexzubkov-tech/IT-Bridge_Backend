using Microsoft.EntityFrameworkCore;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;

namespace CoreService.Infrastructure.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly CoreServiceDbContext _context;

        public TagRepository(CoreServiceDbContext context)
        {
            _context = context;
        }

        public async Task<Tag?> GetByIdWithQuestionsAsync(int id, CancellationToken ct)
        {
            return await _context.Tags
                .Include(t => t.QuestionTags)
                .ThenInclude(qt => qt.Question)
                .FirstOrDefaultAsync(t => t.Id == id, ct);
        }

        public async Task<Tag?> GetByIdAsync(int id, CancellationToken ct)
        {
            return await _context.Tags
                .FirstOrDefaultAsync(t => t.Id == id, ct);
        }

        public async Task<IEnumerable<Tag>> GetAllAsync(CancellationToken ct)
        {
            return await _context.Tags.ToListAsync(ct);
        }

        public async Task<int> CreateAsync(Tag tag, CancellationToken ct)
        {
            await _context.Tags.AddAsync(tag, ct);
            await _context.SaveChangesAsync(ct);
            return tag.Id;
        }

        public async Task<bool> UpdateAsync(Tag tag, CancellationToken ct)
        {
            _context.Tags.Update(tag);
            var rowsAffected = await _context.SaveChangesAsync(ct);
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {
            var tag = await _context.Tags.FindAsync(new object[] { id }, ct);
            if (tag == null) return false;

            _context.Tags.Remove(tag);
            var rowsAffected = await _context.SaveChangesAsync(ct);
            return rowsAffected > 0;
        }
    }
}