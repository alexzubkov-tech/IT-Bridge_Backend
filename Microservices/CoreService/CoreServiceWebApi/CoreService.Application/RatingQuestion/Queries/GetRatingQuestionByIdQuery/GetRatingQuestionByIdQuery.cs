using CoreService.Application.RatingQuestions.Dtos;
using MediatR;

namespace CoreService.Application.RatingQuestions.Queries.GetRatingQuestionByIdQuery
{
    public record GetRatingQuestionByIdQuery(int Id) : IRequest<RatingQuestionDto>;
}