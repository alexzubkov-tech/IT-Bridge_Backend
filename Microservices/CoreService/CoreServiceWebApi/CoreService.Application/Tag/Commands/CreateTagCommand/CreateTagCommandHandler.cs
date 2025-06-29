using CoreService.Application.Tags.Dtos;
using CoreService.Application.Tags.Mapper;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.Tags.Commands.CreateTagCommand
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, TagDto>
    {
        private readonly ITagRepository _tagRepository;

        public CreateTagCommandHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<TagDto> Handle(CreateTagCommand request, CancellationToken ct)
        {
            var entity = request.Dto.ToEntity();
            await _tagRepository.CreateAsync(entity, ct);
            return entity.ToDto();
        }
    }
}