using CoreService.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreService.Domain.Interfaces
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