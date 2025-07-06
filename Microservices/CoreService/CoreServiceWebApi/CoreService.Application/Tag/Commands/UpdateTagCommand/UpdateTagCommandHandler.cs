using MediatR;
using CoreService.Application.Tags.Dtos;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using CoreService.Application.Tags.Mapper;

namespace CoreService.Application.Tags.Commands.UpdateTagCommand
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, TagDto>
    {
        private readonly ITagRepository _tagRepository;

        public UpdateTagCommandHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<TagDto> Handle(UpdateTagCommand request, CancellationToken ct)
        {
            var existing = await _tagRepository.GetByIdAsync(request.Id, ct);
            if (existing == null)
                throw new KeyNotFoundException($"Tag with ID {request.Id} not found.");

            existing.UpdateEntityFromDto(request.Dto);
            await _tagRepository.UpdateAsync(existing, ct);

            return existing.ToDto();
        }
    }
}