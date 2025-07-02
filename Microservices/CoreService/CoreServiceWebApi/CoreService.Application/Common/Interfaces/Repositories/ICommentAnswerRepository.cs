using CoreService.Application.Common.Interfaces.Repositories;
using CoreService.Domain.Entities;


namespace CoreService.Application.Common.Interfaces.Repositories
{
    public interface ICommentAnswerRepository
    {
        Task<CommentAnswer> GetByIdAsync(int id);
        Task<IEnumerable<CommentAnswer>> GetAllAsync();
        Task<int> CreateAsync(CommentAnswer commentAnswer);
        Task<bool> UpdateAsync(CommentAnswer commentAnswer);
        Task<bool> DeleteAsync(int id);
    }
}