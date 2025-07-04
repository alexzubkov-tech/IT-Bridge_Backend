using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoreService.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CoreServiceDbContext _context;

        public CategoryRepository(CoreServiceDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await _context.Categories.AnyAsync(c => c.Id == categoryId);
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories
                .Include(c => c.UserProfiles)
                    .ThenInclude(up => up.Company)
                .Include(c => c.QuestionCategories)
                    .ThenInclude(qc => qc.Question)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<int> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;
            _context.Categories.Remove(category);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }
    }
}