using CoreService.Application.Tags.Dtos;
using MediatR;

namespace CoreService.Application.Tags.Commands.UpdateTagCommand
{
    public record UpdateTagCommand(int Id, UpdateTagDto Dto) : IRequest<TagDto>;
}