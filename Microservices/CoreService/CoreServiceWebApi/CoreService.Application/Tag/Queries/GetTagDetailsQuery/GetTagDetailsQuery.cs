using CoreService.Application.Questions.Dtos;
using CoreService.Application.Tags.Dtos;
using MediatR;

namespace CoreService.Application.Tags.Queries.GetTagDetailsQuery
{
    public record GetTagDetailsQuery(int Id) : IRequest<TagDetailsDto>;
}
