using MediatR;
using CoreService.Application.Tags.Dtos;
using CoreService.Domain.Interfaces;
using CoreService.Application.Tags.Mapper;

namespace CoreService.Application.Tags.Queries.GetTagByIdQuery
{
    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, TagWithQuestionsDto>
    {
        private readonly ITagRepository _tagRepository;

        public GetTagByIdQueryHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<TagWithQuestionsDto> Handle(GetTagByIdQuery request, CancellationToken ct)
        {
            var tag = await _tagRepository.GetByIdWithQuestionsAsync(request.Id, ct);
            if (tag == null)
                throw new KeyNotFoundException($"Tag with ID {request.Id} not found.");

            return tag.ToTagWithQuestionsDto();
        }
    }
}