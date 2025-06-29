using MediatR;
using CoreService.Application.Answers.Dtos;

namespace CoreService.Application.Answers.Queries.GetAnswersByQuestionIdQuery
{
    public record GetAnswersByQuestionIdQuery(int QuestionId) : IRequest<IEnumerable<AnswerWithUserInfoDto>>;
}