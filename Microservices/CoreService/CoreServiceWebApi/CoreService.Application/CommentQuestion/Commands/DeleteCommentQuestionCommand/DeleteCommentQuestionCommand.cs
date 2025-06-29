using MediatR;

namespace CoreService.Application.CommentQuestions.Commands.DeleteCommentQuestionCommand
{
    public record DeleteCommentQuestionCommand(int Id) : IRequest<bool>;
}