using CoreService.Application.Categories.Dtos;
using MediatR;

namespace CoreService.Application.Categories.Commands.UpdateCategoryCommand
{
    public record UpdateCategoryCommand(int Id, UpdateCategoryDto Dto) : IRequest<CategoryDto>;
}