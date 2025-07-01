using MediatR;
using CoreService.Application.CommentQuestions.Dtos;

namespace CoreService.Application.Questions.Queries.GetQuestionCommentQuestionsQuery
{
    public record GetQuestionCommentQuestionsQuery(int Id) : IRequest<IEnumerable<CommentQuestionDto>>;
}