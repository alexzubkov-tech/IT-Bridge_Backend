using MediatR;

namespace CoreService.Application.Questions.Commands.DeleteQuestionCommand
{
    public record DeleteQuestionCommand(int Id) : IRequest<bool>;
}