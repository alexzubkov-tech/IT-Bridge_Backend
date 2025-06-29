using CoreService.Application.CommentQuestions.Dtos;
using MediatR;

namespace CoreService.Application.CommentQuestions.Commands.CreateCommentQuestionCommand
{
    public record CreateCommentQuestionCommand(CreateCommentQuestionDto Dto) : IRequest<CommentQuestionDto>;
}