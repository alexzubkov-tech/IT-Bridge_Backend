using CoreService.Application.UserProfiles.Dtos;
using MediatR;

namespace CoreService.Application.UserProfiles.Commands.CreateUserProfileCommand
{
    public record CreateUserProfileCommand(string UserId, CreateUserProfileDto Dto) : IRequest<UserProfileDto>;
}
