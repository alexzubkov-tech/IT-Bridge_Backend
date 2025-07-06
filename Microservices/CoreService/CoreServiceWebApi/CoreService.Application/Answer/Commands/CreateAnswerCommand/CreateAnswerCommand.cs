using MediatR;
using CoreService.Application.Answers.Dtos;

namespace CoreService.Application.Answers.Commands.CreateAnswerCommand
{
    public record CreateAnswerCommand(CreateAnswerDto Dto) : IRequest<AnswerDto>;
}