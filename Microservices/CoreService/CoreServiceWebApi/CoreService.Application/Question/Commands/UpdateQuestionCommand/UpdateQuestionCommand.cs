using CoreService.Application.Questions.Dtos;
using MediatR;

namespace CoreService.Application.Questions.Commands.UpdateQuestionCommand
{
    public record UpdateQuestionCommand(int Id, UpdateQuestionDto Dto) : IRequest<QuestionDto>;
}