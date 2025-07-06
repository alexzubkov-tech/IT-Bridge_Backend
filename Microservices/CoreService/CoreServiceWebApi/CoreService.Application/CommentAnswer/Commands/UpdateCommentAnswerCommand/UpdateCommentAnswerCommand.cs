using MediatR;
using CoreService.Application.CommentAnswers.Dtos;

namespace CoreService.Application.CommentAnswers.Commands.UpdateCommentAnswerCommand
{
    public record UpdateCommentAnswerCommand(int Id, UpdateCommentAnswerDto Dto) : IRequest<CommentAnswerDto>;
}