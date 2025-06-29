using CoreService.Application.Tags.Dtos;
using MediatR;

namespace CoreService.Application.Tags.Queries.GetAllTagsQuery
{
    public record GetAllTagsQuery() : IRequest<IEnumerable<TagDto>>;
}