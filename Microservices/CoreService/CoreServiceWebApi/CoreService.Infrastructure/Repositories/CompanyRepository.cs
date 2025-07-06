using Microsoft.EntityFrameworkCore;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;

namespace CoreService.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CoreServiceDbContext _context;

        public CompanyRepository(CoreServiceDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CompanyExists(int companyId)
        {
            return await _context.Companies.AnyAsync(c => c.Id == companyId);
        }

        public async Task<Company> GetByIdAsync(int id, CancellationToken ct)
        {
            return await _context.Companies
                .Include(c => c.UserProfiles)
                .FirstOrDefaultAsync(c => c.Id == id, ct);
        }

        public async Task<IEnumerable<Company>> GetAllAsync(CancellationToken ct)
        {
            return await _context.Companies.ToListAsync(ct);
        }

        public async Task<int> CreateAsync(Company company, CancellationToken ct)
        {
            await _context.Companies.AddAsync(company, ct);
            await _context.SaveChangesAsync(ct);
            return company.Id;
        }

        public async Task<bool> UpdateAsync(Company company, CancellationToken ct)
        {
            _context.Companies.Update(company);
            var rowsAffected = await _context.SaveChangesAsync(ct);
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {
            var company = await _context.Companies.FindAsync(new object[] { id }, ct);
            if (company == null) return false;
            _context.Companies.Remove(company);
            var rowsAffected = await _context.SaveChangesAsync(ct);
            return rowsAffected > 0;
        }
    }
}