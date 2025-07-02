using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.Events;
using BuildingBlocks.EventBusRabbitMQ;
using CoreService.Application.Questions.Dtos;
using CoreService.Application.Questions.Mapper;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.Questions.Commands.CreateQuestionCommand
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, QuestionDto>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IEventBusPublisher _eventBuspublisher;


        public CreateQuestionCommandHandler(
            IQuestionRepository questionRepository,
            IEventBusPublisher eventBusPublisher)
        {
            _questionRepository = questionRepository;
            _eventBuspublisher = eventBusPublisher;
        }

        public async Task<QuestionDto> Handle(CreateQuestionCommand request, CancellationToken ct)
        {
            // 1. Преобразуем DTO в сущность с UserProfileId
            var entity = request.Dto.ToEntity(request.UserProfileId);

            // 2. Сохраняем вопрос
            await _questionRepository.CreateAsync(entity, ct);

            // 3. Получаем названия специализаций (категорий)
            var specializationNames = await _questionRepository
                .GetSpecializationNamesByCategoryIds(request.Dto.CategoryIds, ct);


            // 5. Публикуем в RabbitMQ
            _eventBuspublisher.Publish(new QuestionCreatedNotificationEvent(entity.Title, specializationNames));


            // 6. Возвращаем результат
            return entity.ToDto();
        }
    }
}