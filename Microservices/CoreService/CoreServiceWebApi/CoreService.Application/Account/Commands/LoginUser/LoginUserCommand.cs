using CoreService.Application.Account.Dtos;
using MediatR;

namespace Application.Account.Commands
{
    public record LoginUserCommand(LoginDto LoginDto) : IRequest<NewUserDto>;
}