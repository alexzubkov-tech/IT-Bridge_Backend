using MediatR;
using CoreService.Application.Answers.Dtos;

namespace CoreService.Application.Answers.Commands.UpdateAnswerCommand
{
    public record UpdateAnswerCommand(int Id, UpdateAnswerDto Dto) : IRequest<AnswerDto>;
}