using CoreService.Application.CommentQuestions.Dtos;
using MediatR;

namespace CoreService.Application.CommentQuestions.Commands.UpdateCommentQuestionCommand
{
    public record UpdateCommentQuestionCommand(int Id, UpdateCommentQuestionDto Dto) : IRequest<CommentQuestionDto>;
}