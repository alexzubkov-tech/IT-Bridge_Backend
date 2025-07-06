using System.Collections.Concurrent;
using NotificationService.Application.Interfaces.Repositories;
using NotificationService.Domain.Entities;

namespace NotificationService.Infrastructure.Repositories
{
    public class InMemoryQuestionRepository : IQuestionRepository
    {
        private readonly ConcurrentDictionary<string, Question> _questions = new();

        public async Task AddAsync(Question question)
        {
            _questions.TryAdd(question.Id, question);
            await Task.CompletedTask;
        }
    }
}
