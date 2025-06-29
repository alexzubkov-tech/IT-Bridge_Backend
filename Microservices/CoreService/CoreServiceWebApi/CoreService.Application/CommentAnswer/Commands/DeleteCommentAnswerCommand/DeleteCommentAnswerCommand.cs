using MediatR;

namespace CoreService.Application.CommentAnswers.Commands.DeleteCommentAnswerCommand
{
    public record DeleteCommentAnswerCommand(int Id) : IRequest<bool>;
}