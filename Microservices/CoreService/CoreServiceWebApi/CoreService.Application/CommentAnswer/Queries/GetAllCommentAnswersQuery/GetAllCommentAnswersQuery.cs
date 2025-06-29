using MediatR;
using CoreService.Application.CommentAnswers.Dtos;

namespace CoreService.Application.CommentAnswers.Queries.GetAllCommentAnswersQuery
{
    public record GetAllCommentAnswersQuery() : IRequest<IEnumerable<CommentAnswerDto>>;
}