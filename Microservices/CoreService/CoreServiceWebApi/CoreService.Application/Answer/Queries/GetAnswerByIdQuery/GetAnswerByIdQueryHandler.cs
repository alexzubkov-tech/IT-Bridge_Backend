using CoreService.Application.Answers.Dtos;
using CoreService.Application.Answers.Mapper;
using CoreService.Application.RatingAnswers.Mapper;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.Answers.Queries.GetAnswerByIdQuery
{
    public class GetAnswerByIdQueryHandler : IRequestHandler<GetAnswerByIdQuery, AnswerDetailsDto>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IRatingAnswerRepository _ratingAnswerRepository;

        public GetAnswerByIdQueryHandler(IAnswerRepository answerRepository, IRatingAnswerRepository ratingAnswerRepository)
        {
            _answerRepository = answerRepository;
            _ratingAnswerRepository = ratingAnswerRepository;
        }

        public async Task<AnswerDetailsDto> Handle(GetAnswerByIdQuery request, CancellationToken ct)
        {
            var answer = await _answerRepository.GetByIdAsync(request.Id);
            if (answer == null)
                throw new KeyNotFoundException("Answer not found");

            var rating = await _ratingAnswerRepository.GetAllRatingAnswerToAnswerAsync(request.Id);

            var answerDto = answer.ToDetailsDto();
            var ratingResult = rating.ToUserRating();

            answerDto.RatingPositive = ratingResult.RatingPositive;
            answerDto.RatingNegative = ratingResult.RatingNegative;

            return answerDto;
        }
    }
}