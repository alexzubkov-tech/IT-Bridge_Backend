using NotificationService.Domain.Entities;

namespace NotificationService.Application.Interfaces.Repositories
{
    public interface IQuestionRepository
    {
        Task AddAsync(Question question);
    }
}
