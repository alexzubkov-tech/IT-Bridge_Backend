using CoreService.Application.Categories.Dtos;
using MediatR;

namespace CoreService.Application.Categories.Commands.CreateCategoryCommand
{
    public record CreateCategoryCommand(CreateCategoryDto Dto) : IRequest<CategoryDto>;
}