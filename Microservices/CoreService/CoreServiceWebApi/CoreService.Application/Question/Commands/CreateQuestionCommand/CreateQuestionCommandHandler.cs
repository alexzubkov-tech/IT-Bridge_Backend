//using BuildingBlock.Events;
//using BuildingBlocks.EventBus.Abstractions;
//using CoreService.Application.Questions.Dtos;
//using CoreService.Application.Questions.Mapper;
//using CoreService.Domain.Entities;
//using CoreService.Domain.Interfaces;
//using MediatR;

//namespace CoreService.Application.Questions.Commands.CreateQuestionCommand
//{
//    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, QuestionDetailsDto>
//    {
//        private readonly IQuestionRepository _questionRepository;
//        private readonly IEventBusPublisher _eventBuspublisher;

//        public CreateQuestionCommandHandler(
//            IQuestionRepository questionRepository,
//            IEventBusPublisher eventBusPublisher)
//        {
//            _questionRepository = questionRepository;
//            _eventBuspublisher = eventBusPublisher;
//        }

//        public async Task<QuestionDetailsDto> Handle(CreateQuestionCommand request, CancellationToken ct)
//        {
//            var entity = request.Dto.ToEntity(request.UserProfileId);
//            var questionId = await _questionRepository.CreateAsync(entity, ct);


//            var question = await _questionRepository.GetByIdAsync(questionId, ct);
//            if (question == null)
//                throw new KeyNotFoundException($"Question with ID {questionId} not found.");


//            _eventBuspublisher.Publish(new TestEvent("Привет сервис уведомлений!"));
//            return question.ToDetailsDto();
//        }
//    }
//}

using BuildingBlock.Events;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.Events;
using CoreService.Application.Questions.Dtos;
using CoreService.Application.Questions.Mapper;
using CoreService.Application.UserProfile.Mapper;
using CoreService.Application.UserProfiles.Dtos;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

// CreateQuestionCommandHandler.cs

namespace CoreService.Application.Questions.Commands.CreateQuestionCommand
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, QuestionDetailsDto>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IEventBusPublisher _eventBuspublisher;
        private readonly IConfiguration _configuration;

        public CreateQuestionCommandHandler(
            IQuestionRepository questionRepository,
            IUserProfileRepository userProfileRepository,
            IEventBusPublisher eventBusPublisher,
            IConfiguration configuration)
        {
            _questionRepository = questionRepository;
            _userProfileRepository = userProfileRepository;
            _eventBuspublisher = eventBusPublisher;
            _configuration = configuration;
        }

        public async Task<QuestionDetailsDto> Handle(CreateQuestionCommand request, CancellationToken ct)
        {
            // Создание вопроса
            var entity = request.Dto.ToEntity(request.UserProfileId);
            var questionId = await _questionRepository.CreateAsync(entity, ct);

            // Получение вопроса с категориями
            var question = await _questionRepository.GetByIdAsync(questionId, ct)
                ?? throw new KeyNotFoundException($"Question with ID {questionId} not found.");

            // Получаем CategoryIds напрямую из DTO
            var categoryIds = request.Dto.CategoryIds;

            string backendApiUrl = _configuration["AppSettings:BackendApiUrl"];
            string link = $"{backendApiUrl}/api/questions/{question.Id}";

            // Публикация события с массивом CategoryIds
            _eventBuspublisher.Publish(new QuestionCreatedNotificationEvent(
                question.Id,
                question.Title,
                link,
                categoryIds));

            // Получение пользователей по категориям (опционально, если нужно для других целей)
            IEnumerable<UserProfileDto> usersDto = categoryIds.Any()
                ? (await _userProfileRepository.GetByCategoryIdsAsync(categoryIds))
                    .Select(u => u.ToDto())
                : Enumerable.Empty<UserProfileDto>();

            return question.ToDetailsDto();
        }
    }
}