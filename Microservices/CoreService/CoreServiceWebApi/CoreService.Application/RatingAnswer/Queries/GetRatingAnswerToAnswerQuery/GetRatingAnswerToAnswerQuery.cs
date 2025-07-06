using CoreService.Application.RatingAnswers.Dtos;
using MediatR;

namespace CoreService.Application.RatingAnswers.Queries.GetRatingAnswerToAnswerQuery
{
    public record GetRatingAnswerToAnswerQuery(int answerId) : IRequest<IEnumerable<RatingAnswerDto>>;
}
