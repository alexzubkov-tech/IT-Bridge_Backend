using CoreService.Application.RatingQuestions.Dtos;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.RatingQuestions.Queries.GetRatingByQuestion
{
    public class GetRatingByQuestionQueryHandler : IRequestHandler<GetRatingByQuestionQuery, IEnumerable<RatingByQuestionDto>>
    {
        private readonly IRatingQuestionRepository _ratingQuestionRepository;

        public GetRatingByQuestionQueryHandler(IRatingQuestionRepository ratingQuestionRepository)
        {
            _ratingQuestionRepository = ratingQuestionRepository;
        }

        public async Task<IEnumerable<RatingByQuestionDto>> Handle(GetRatingByQuestionQuery request, CancellationToken ct)
        {
            var ratings = await _ratingQuestionRepository.GetAllAsync();

            var grouped = ratings
                .GroupBy(r => r.QuestionId)
                .Select(g => new RatingByQuestionDto
                {
                    QuestionId = g.Key,
                    RatingPositive = g.Count(r => r.IsGoodAnswer),
                    RatingNegative = g.Count(r => !r.IsGoodAnswer)
                })
                .ToList();

            return grouped;
        }
    }
}