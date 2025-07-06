using MediatR;

namespace CoreService.Application.Answers.Commands.DeleteAnswerCommand
{
    public record DeleteAnswerCommand(int Id) : IRequest<bool>;
}