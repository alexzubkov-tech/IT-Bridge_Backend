using CoreService.Application.Common.Interfaces.Repositories;
using CoreService.Domain.Entities;

namespace CoreService.Application.Common.Interfaces.Repositories
{
    public interface IQuestionRepository
    {
        Task<Question?> GetByIdAsync(int id, CancellationToken ct);
        Task<Question?> GetByIdWithDetailsAsync(int id, CancellationToken ct);
        Task<IEnumerable<Question>> GetAllAsync(CancellationToken ct);
        Task<int> CreateAsync(Question question, CancellationToken ct);
        Task<bool> UpdateAsync(Question question, CancellationToken ct);
        Task<bool> DeleteAsync(int id, CancellationToken ct);
        Task<List<string>> GetCategoryNamesByIdsAsync(List<int> categoryIds, CancellationToken ct);
    }
}