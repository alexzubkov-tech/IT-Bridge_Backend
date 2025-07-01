using CoreService.Application.CommentAnswers.Dtos;
using MediatR;

namespace CoreService.Application.CommentAnswers.Queries.GetCommentAnswersToAnswerQuery
{
    public record GetCommentAnswersToAnswerQuery(int answerId) : IRequest<IEnumerable<CommentAnswerDto>>;
}
