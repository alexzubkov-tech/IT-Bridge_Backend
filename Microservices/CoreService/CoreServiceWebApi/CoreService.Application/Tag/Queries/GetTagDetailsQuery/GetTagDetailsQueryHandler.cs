using CoreService.Application.Common.Interfaces;
using CoreService.Application.Tags.Dtos;
using CoreService.Application.Tags.Mapper;
using MediatR;

namespace CoreService.Application.Tags.Queries.GetTagDetailsQuery
{
    public class GetTagDetailsQueryHandler : IRequestHandler<GetTagDetailsQuery, TagDetailsDto>
    {
        private readonly ICoreServiceDbContext _context;
        private readonly ITagRepository _TagRepository;

        public GetTagDetailsQueryHandler(ICoreServiceDbContext context, ITagRepository TagRepository)
        {
            _context = context;
            _TagRepository = TagRepository;
        }

        public async Task<TagDetailsDto> Handle(GetTagDetailsQuery request, CancellationToken ct)
        {

            var Tag = await _TagRepository.GetByIdWithQuestionsAsync(request.Id, ct);
            if (Tag == null)
                throw new KeyNotFoundException($"Tag with ID {request.Id} not found.");

            return Tag.ToDetailsDto();
        }
    }
}
