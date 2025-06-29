using MediatR;
using CoreService.Application.Tags.Dtos;
using CoreService.Domain.Interfaces;
using CoreService.Application.Tags.Mapper;

namespace CoreService.Application.Tags.Queries.GetAllTagsQuery
{
    public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, IEnumerable<TagDto>>
    {
        private readonly ITagRepository _tagRepository;

        public GetAllTagsQueryHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<IEnumerable<TagDto>> Handle(GetAllTagsQuery request, CancellationToken ct)
        {
            var tags = await _tagRepository.GetAllAsync(ct);
            return tags.Select(t => t.ToDto());
        }
    }
}