using CoreService.Application.CommentQuestions.Dtos;
using MediatR;

namespace CoreService.Application.CommentQuestions.Queries.GetAllCommentQuestionsQuery
{
    public record GetAllCommentQuestionsQuery() : IRequest<IEnumerable<CommentQuestionDto>>;
}