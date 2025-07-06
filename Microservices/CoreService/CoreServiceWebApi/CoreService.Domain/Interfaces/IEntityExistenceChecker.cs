using System.Threading.Tasks;

namespace CoreService.Domain.Interfaces
{
    public interface IEntityExistenceChecker
    {
        Task<bool> UserProfileExists(int id);
        Task<bool> QuestionExists(int id);
        Task<bool> AnswerExists(int id);
        Task<bool> CategoryExists(int id);
        Task<bool> TagExists(int id);
        Task<bool> CompanyExists(int id);
        Task<bool> CategoriesExist(List<int> categoryIds, CancellationToken ct);
        Task<bool> TagsExist(List<int> tagIds, CancellationToken ct);
    }
}