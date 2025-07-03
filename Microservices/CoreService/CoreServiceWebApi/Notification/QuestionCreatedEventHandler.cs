using BuildingBlock.Events;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.Events;
using NotificationService.Application.Interfaces.Repositories;
using NotificationService.Domain.Entities;

namespace Notification
{
    public class QuestionCreatedEventHandler : IEventHandler<QuestionCreatedNotificationEvent>
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionCreatedEventHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task Handle(QuestionCreatedNotificationEvent @event)
        {

            // Создание сущности Question
            var question = new Question(
                id: @event.QuestionId.ToString(),
                title: @event.Title,
                specializationNames: @event.SpecializationNames
            );

            // Сохранение вопроса в хранилище
            await _questionRepository.AddAsync(question);

        }
    }
}
