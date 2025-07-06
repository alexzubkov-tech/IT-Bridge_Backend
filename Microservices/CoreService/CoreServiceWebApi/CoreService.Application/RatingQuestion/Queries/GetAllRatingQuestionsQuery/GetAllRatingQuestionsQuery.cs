using CoreService.Application.RatingQuestions.Dtos;
using MediatR;

namespace CoreService.Application.RatingQuestions.Queries.GetAllRatingQuestionsQuery
{
    public record GetAllRatingQuestionsQuery() : IRequest<IEnumerable<RatingQuestionDto>>;
}