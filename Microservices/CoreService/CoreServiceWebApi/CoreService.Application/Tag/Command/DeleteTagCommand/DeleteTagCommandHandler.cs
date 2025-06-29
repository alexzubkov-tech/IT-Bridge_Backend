using MediatR;
using CoreService.Domain.Interfaces;

namespace CoreService.Application.Tags.Commands.DeleteTagCommand
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, bool>
    {
        private readonly ITagRepository _tagRepository;

        public DeleteTagCommandHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<bool> Handle(DeleteTagCommand request, CancellationToken ct)
        {
            var result = await _tagRepository.DeleteAsync(request.Id, ct);
            if (!result)
                throw new KeyNotFoundException($"Tag with ID {request.Id} not found.");

            return result;
        }
    }
}