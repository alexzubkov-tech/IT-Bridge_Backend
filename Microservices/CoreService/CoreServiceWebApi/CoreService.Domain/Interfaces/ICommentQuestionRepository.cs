using CoreService.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreService.Domain.Interfaces
{
    public interface ICommentQuestionRepository
    {
        Task<CommentQuestion> GetByIdAsync(int id);
        Task<IEnumerable<CommentQuestion>> GetAllAsync();
        Task<int> CreateAsync(CommentQuestion comment);
        Task<bool> UpdateAsync(CommentQuestion comment);
        Task<bool> DeleteAsync(int id);
    }
}