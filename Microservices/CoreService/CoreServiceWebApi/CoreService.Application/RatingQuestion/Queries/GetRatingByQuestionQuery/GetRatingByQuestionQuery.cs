using CoreService.Application.RatingQuestions.Dtos;
using MediatR;

namespace CoreService.Application.RatingQuestions.Queries.GetRatingByQuestion
{
    public record GetRatingByQuestionQuery() : IRequest<IEnumerable<RatingByQuestionDto>>;
}