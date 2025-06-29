using MediatR;
using CoreService.Application.CommentAnswers.Dtos;

namespace CoreService.Application.CommentAnswers.Queries.GetCommentAnswerByIdQuery
{
    public record GetCommentAnswerByIdQuery(int Id) : IRequest<CommentAnswerDto>;
}