using CoreService.Application.Common.Interfaces.Repositories;
using CoreService.Domain.Entities;

namespace CoreService.Application.Common.Interfaces.Repositories
{
    public interface IAnswerRepository
    {
        Task<Answer> GetByIdAsync(int id);
        Task<IEnumerable<Answer>> GetAllAsync();
        Task<IEnumerable<Answer>> GetByQuestionIdAsync(int questionId);
        Task<int> CreateAsync(Answer answer);
        Task<bool> UpdateAsync(Answer answer);
        Task<bool> DeleteAsync(int id);
    }
}