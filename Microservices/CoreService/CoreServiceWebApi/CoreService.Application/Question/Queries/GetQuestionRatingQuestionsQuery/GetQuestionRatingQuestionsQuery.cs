using CoreService.Application.RatingQuestions.Dtos;
using MediatR;

namespace CoreService.Application.Questions.Queries.GetQuestionRatingQuestionQuery
{
    public record GetQuestionRatingQuestionsQuery(int Id) : IRequest<IEnumerable<RatingQuestionDto>>;
}
