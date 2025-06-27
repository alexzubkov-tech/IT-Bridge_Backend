using CoreService.Application.UserProfiles.Dtos;
using MediatR;

namespace CoreService.Application.UserProfiles.Commands.UpdateUserProfileCommand
{
    public record UpdateUserProfileCommand(int Id, UpdateUserProfileDto Dto) : IRequest<UserProfileDto>;
}
