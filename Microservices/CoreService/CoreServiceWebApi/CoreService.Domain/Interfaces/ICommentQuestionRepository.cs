using CoreService.Domain.Entities;

namespace CoreService.Domain.Interfaces
{
    public interface ICommentQuestionRepository
    {
        Task<CommentQuestion> GetByIdAsync(int id);
        Task<IEnumerable<CommentQuestion>> GetAllAsync();
        Task<IEnumerable<CommentQuestion>> GetAllToQuestionAsync(int id);
        Task<int> CreateAsync(CommentQuestion comment);
        Task<bool> UpdateAsync(CommentQuestion comment);
        Task<bool> DeleteAsync(int id);
    }
}