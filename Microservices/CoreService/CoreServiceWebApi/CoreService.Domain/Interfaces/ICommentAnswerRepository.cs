using CoreService.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreService.Domain.Interfaces
{
    public interface ICommentAnswerRepository
    {
        Task<CommentAnswer> GetByIdAsync(int id);
        Task<IEnumerable<CommentAnswer>> GetAllAsync();
        Task<IEnumerable<CommentAnswer>> GetAllToAnswerAsync(int id);
        Task<int> CreateAsync(CommentAnswer commentAnswer);
        Task<bool> UpdateAsync(CommentAnswer commentAnswer);
        Task<bool> DeleteAsync(int id);
    }
}