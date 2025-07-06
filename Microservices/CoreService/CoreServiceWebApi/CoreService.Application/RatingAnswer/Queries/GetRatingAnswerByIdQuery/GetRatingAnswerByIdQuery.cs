using MediatR;
using CoreService.Application.RatingAnswers.Dtos;

namespace CoreService.Application.RatingAnswers.Queries.GetRatingAnswerByIdQuery
{
    public record GetRatingAnswerByIdQuery(int Id) : IRequest<RatingAnswerDto>;
}