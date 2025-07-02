using CoreService.Application.Common.Interfaces.Repositories;
using CoreService.Domain.Entities;

namespace CoreService.Application.Common.Interfaces.Repositories
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