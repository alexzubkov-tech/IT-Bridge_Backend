using CoreService.Application.Tags.Dtos;
using MediatR;

namespace CoreService.Application.Tags.Commands.CreateTagCommand
{
    public record CreateTagCommand(CreateTagDto Dto) : IRequest<TagDto>;
}