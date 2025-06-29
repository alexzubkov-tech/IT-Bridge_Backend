using MediatR;

namespace CoreService.Application.Tags.Commands.DeleteTagCommand
{
    public record DeleteTagCommand(int Id) : IRequest<bool>;
}