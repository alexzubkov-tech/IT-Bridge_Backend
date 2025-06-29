using MediatR;

namespace CoreService.Application.Categories.Commands.DeleteCategoryCommand
{
    public record DeleteCategoryCommand(int Id) : IRequest<bool>;
}