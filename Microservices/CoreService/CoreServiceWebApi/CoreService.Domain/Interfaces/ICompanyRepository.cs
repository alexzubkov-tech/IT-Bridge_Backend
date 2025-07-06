using CoreService.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreService.Domain.Interfaces
{
    public interface ICompanyRepository
    {
        Task<bool> CompanyExists(int companyId);
        Task<Company> GetByIdAsync(int id, CancellationToken ct);
        Task<IEnumerable<Company>> GetAllAsync(CancellationToken ct);
        Task<int> CreateAsync(Company company, CancellationToken ct);
        Task<bool> UpdateAsync(Company company, CancellationToken ct);
        Task<bool> DeleteAsync(int id, CancellationToken ct);
    }
}