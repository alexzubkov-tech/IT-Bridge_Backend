using MediatR;
using CoreService.Application.CommentAnswers.Dtos;

namespace CoreService.Application.CommentAnswers.Commands.CreateCommentAnswerCommand
{
    public record CreateCommentAnswerCommand(CreateCommentAnswerDto Dto) : IRequest<CommentAnswerDto>;
}