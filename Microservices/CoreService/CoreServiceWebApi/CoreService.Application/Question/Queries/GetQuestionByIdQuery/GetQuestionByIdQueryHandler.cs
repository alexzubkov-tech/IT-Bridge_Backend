using CoreService.Application.Questions.Dtos;
using CoreService.Application.Questions.Mapper;
using CoreService.Application.RatingQuestions.Mapper;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.Questions.Queries.GetQuestionByIdQuery
{
    public class GetQuestionByIdQueryHandler : IRequestHandler<GetQuestionByIdQuery, QuestionDetailsDto>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IRatingQuestionRepository _ratingQuestionRepository;

        public GetQuestionByIdQueryHandler(IQuestionRepository questionRepository, IRatingQuestionRepository ratingQuestionRepository)
        {
            _questionRepository = questionRepository;
            _ratingQuestionRepository = ratingQuestionRepository;
        }

        public async Task<QuestionDetailsDto> Handle(GetQuestionByIdQuery request, CancellationToken ct)
        {
            var question = await _questionRepository.GetByIdAsync(request.Id, ct);
            if (question == null)
                throw new KeyNotFoundException($"Question with ID {request.Id} not found.");

            var rating = await _ratingQuestionRepository.GetAllRatingQuestionToQuestionAsync(request.Id);

            var questionDto = question.ToDetailsDto();
            var ratingToUser = rating.ToQuestionRating();

            questionDto.RatingPositive = ratingToUser.RatingPositive;
            questionDto.RatingNegative = ratingToUser.RatingNegative;

            return questionDto;
        }
    }
}