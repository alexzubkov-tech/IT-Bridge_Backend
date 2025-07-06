using CoreService.Application.Account.Dtos;
using MediatR;

namespace Application.Account.Commands
{
    public record RegisterUserCommand(RegisterDto RegisterDto) : IRequest<NewUserDto>;
}