using CoreService.Application.Categories.Dtos;
using MediatR;

namespace CoreService.Application.Categories.Queries.GetAllCategoriesQuery
{
    public record GetAllCategoriesQuery() : IRequest<IEnumerable<CategoryDto>>;
}