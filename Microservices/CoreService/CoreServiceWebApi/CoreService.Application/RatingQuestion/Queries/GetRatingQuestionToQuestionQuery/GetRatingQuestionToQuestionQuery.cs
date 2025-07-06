using CoreService.Application.RatingQuestions.Dtos;
using MediatR;

namespace CoreService.Application.RatingQuestions.Queries.GetQuestionRatingQuestionsQuery
{
    public record GetRatingQuestionToQuestionQuery(int qustionId) : IRequest<IEnumerable<RatingQuestionDto>>;
}
