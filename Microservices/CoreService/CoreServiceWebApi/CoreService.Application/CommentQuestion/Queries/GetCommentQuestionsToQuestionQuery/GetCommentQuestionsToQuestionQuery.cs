using MediatR;
using CoreService.Application.CommentQuestions.Dtos;

namespace CoreService.Application.CommentQuestions.Queries.GetQuestionCommentQuestionsQuery
{
    public record GetCommentQuestionsToQuestionQuery(int questionId) : IRequest<IEnumerable<CommentQuestionDto>>;
}