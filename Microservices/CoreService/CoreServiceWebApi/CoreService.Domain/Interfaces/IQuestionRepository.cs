using CoreService.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreService.Domain.Interfaces
{
    public interface IQuestionRepository
    {
        Task<Question?> GetByIdAsync(int id, CancellationToken ct);
        Task<Question?> GetByIdWithDetailsAsync(int id, CancellationToken ct);
        Task<IEnumerable<Question>> GetAllAsync(CancellationToken ct);
        Task<int> CreateAsync(Question question, CancellationToken ct);
        Task<bool> UpdateAsync(Question question, CancellationToken ct);
        Task<bool> DeleteAsync(int id, CancellationToken ct);
    }
}