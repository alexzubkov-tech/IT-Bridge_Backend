using BuildingBlock.Events;
using BuildingBlocks.EventBus.Abstractions;
using CoreService.Application.Questions.Dtos;
using CoreService.Application.Questions.Mapper;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.Questions.Commands.CreateQuestionCommand
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, QuestionDetailsDto>
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

        public async Task<QuestionDetailsDto> Handle(CreateQuestionCommand request, CancellationToken ct)
        {
            var entity = request.Dto.ToEntity(request.UserProfileId);
            var questionId = await _questionRepository.CreateAsync(entity, ct);


            var question = await _questionRepository.GetByIdAsync(questionId, ct);
            if (question == null)
                throw new KeyNotFoundException($"Question with ID {questionId} not found.");


            _eventBuspublisher.Publish(new TestEvent("Привет сервис уведомлений!"));
            return question.ToDetailsDto();
        }
    }
}