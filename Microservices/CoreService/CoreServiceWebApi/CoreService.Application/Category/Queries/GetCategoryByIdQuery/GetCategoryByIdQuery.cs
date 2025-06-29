using CoreService.Application.Categories.Dtos;
using MediatR;

namespace CoreService.Application.Categories.Queries.GetCategoryByIdQuery
{
    public record GetCategoryByIdQuery(int Id) : IRequest<CategoryWithProfilesDto>;
}