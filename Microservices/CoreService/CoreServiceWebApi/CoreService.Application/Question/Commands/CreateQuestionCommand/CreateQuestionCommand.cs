using CoreService.Application.Questions.Dtos;
using CoreService.Application.UserProfiles.Dtos;
using CoreService.Domain.Entities;
using MediatR;

namespace CoreService.Application.Questions.Commands.CreateQuestionCommand
{
    public record CreateQuestionCommand(CreateQuestionDto Dto, int UserProfileId) : IRequest<QuestionDetailsDto>;
}