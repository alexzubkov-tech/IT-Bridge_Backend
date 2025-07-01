using CoreService.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreService.Domain.Interfaces
{
    public interface IRatingQuestionRepository
    {
        Task<RatingQuestion> GetByIdAsync(int id);
        Task<IEnumerable<RatingQuestion>> GetAllAsync();
        Task<IEnumerable<RatingQuestion>> GetAllToQuestionAsync(int id);
        Task<int> CreateAsync(RatingQuestion rating);
        Task<bool> UpdateAsync(RatingQuestion rating);
        Task<bool> DeleteAsync(int id);
    }
}