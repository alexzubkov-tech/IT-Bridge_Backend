using CoreService.Domain.Entities;

public interface ITagRepository
{
    Task<Tag?> GetByIdAsync(int id, CancellationToken ct);
    Task<Tag?> GetByIdWithQuestionsAsync(int id, CancellationToken ct);
    Task<IEnumerable<Tag>> GetAllAsync(CancellationToken ct);
    Task<int> CreateAsync(Tag tag, CancellationToken ct);
    Task<bool> UpdateAsync(Tag tag, CancellationToken ct);
    Task<bool> DeleteAsync(int id, CancellationToken ct);
    Task<bool> TagExistsWithName(string name, CancellationToken ct = default);
}