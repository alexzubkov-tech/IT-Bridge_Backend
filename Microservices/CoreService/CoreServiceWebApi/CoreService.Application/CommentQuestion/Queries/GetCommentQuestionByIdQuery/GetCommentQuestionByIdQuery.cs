using CoreService.Application.CommentQuestions.Dtos;
using MediatR;

namespace CoreService.Application.CommentQuestions.Queries.GetCommentQuestionByIdQuery
{
    public record GetCommentQuestionByIdQuery(int Id) : IRequest<CommentQuestionDto>;
}