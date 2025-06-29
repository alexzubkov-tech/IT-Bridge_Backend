using CoreService.Application.Tags.Dtos;
using MediatR;

namespace CoreService.Application.Tags.Queries.GetTagByIdQuery
{
    public record GetTagByIdQuery(int Id) : IRequest<TagWithQuestionsDto>;
}

