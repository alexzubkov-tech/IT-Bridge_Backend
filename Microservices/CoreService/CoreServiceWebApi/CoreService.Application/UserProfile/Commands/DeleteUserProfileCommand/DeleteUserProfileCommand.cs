
using MediatR;

namespace CoreService.Application.UserProfiles.Commands.DeleteUserProfileCommand
{
    public record DeleteUserProfileCommand(int Id) : IRequest<bool>;
}
