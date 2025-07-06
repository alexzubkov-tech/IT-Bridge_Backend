using MediatR;
using CoreService.Application.RatingAnswers.Dtos;

namespace CoreService.Application.RatingAnswers.Queries.GetAllRatingAnswersQuery
{
    public record GetAllRatingAnswersQuery() : IRequest<IEnumerable<RatingAnswerDto>>;
}