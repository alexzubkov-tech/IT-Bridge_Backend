using CoreService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoreService.Infrastructure.Repositories
{
    public class EntityExistenceChecker : IEntityExistenceChecker
    {
        private readonly CoreServiceDbContext _context;

        public EntityExistenceChecker(CoreServiceDbContext context)
        {
            _context = context;
        }

        public async Task<bool> UserProfileExists(int id)
        {
            return await _context.UserProfiles.AnyAsync(u => u.Id == id);
        }

        public async Task<bool> QuestionExists(int id)
        {
            return await _context.Questions.AnyAsync(q => q.Id == id);
        }

        public async Task<bool> AnswerExists(int id)
        {
            return await _context.Answers.AnyAsync(a => a.Id == id);
        }

        public async Task<bool> CategoryExists(int id)
        {
            return await _context.Categories.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> TagExists(int id)
        {
            return await _context.Tags.AnyAsync(t => t.Id == id);
        }

        public async Task<bool> CompanyExists(int id)
        {
            return await _context.Companies.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CategoriesExist(List<int> categoryIds, CancellationToken ct)
        {
            if (!categoryIds.Any()) return true;

            var existingCount = await _context.Categories
                .Where(c => categoryIds.Contains(c.Id))
                .CountAsync(ct);

            return existingCount == categoryIds.Count;
        }

        public async Task<bool> TagsExist(List<int> tagIds, CancellationToken ct)
        {
            if (!tagIds.Any()) return true;

            var existingCount = await _context.Tags
                .Where(t => tagIds.Contains(t.Id))
                .CountAsync(ct);

            return existingCount == tagIds.Count;
        }
    }
}