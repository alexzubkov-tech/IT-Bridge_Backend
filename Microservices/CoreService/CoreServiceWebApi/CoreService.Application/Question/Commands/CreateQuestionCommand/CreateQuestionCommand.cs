using CoreService.Application.Questions.Dtos;
using MediatR;

namespace CoreService.Application.Questions.Commands.CreateQuestionCommand
{
    public record CreateQuestionCommand(CreateQuestionDto Dto, int UserProfileId) : IRequest<QuestionDetailsDto>;
}