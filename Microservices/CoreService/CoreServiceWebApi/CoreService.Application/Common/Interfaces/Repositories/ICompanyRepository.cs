using CoreService.Application.Common.Interfaces.Repositories;
using CoreService.Domain.Entities;


namespace CoreService.Application.Common.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        Task<Company> GetByIdAsync(int id, CancellationToken ct);
        Task<IEnumerable<Company>> GetAllAsync(CancellationToken ct);
        Task<int> CreateAsync(Company company, CancellationToken ct);
        Task<bool> UpdateAsync(Company company, CancellationToken ct);
        Task<bool> DeleteAsync(int id, CancellationToken ct);
    }
}