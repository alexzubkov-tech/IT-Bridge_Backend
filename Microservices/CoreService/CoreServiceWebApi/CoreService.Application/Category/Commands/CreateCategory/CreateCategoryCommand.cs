using Application.Categories.DTOs;
using CoreService.Application.Common.Interfaces;
using CoreService.Domain.Entities;
using MediatR;

namespace Application.Categories.Commands;

public record CreateCategoryCommand(CreateCategoryDto CategoryDto) : IRequest<CategoryDto>;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    private readonly ICoreServiceDbContext _context;

    public CreateCategoryCommandHandler(ICoreServiceDbContext context)
    {
        _context = context;
    }

    public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = new Category
        {
            Id = Guid.NewGuid(),
            Name = request.CategoryDto.Name,
            Description = request.CategoryDto.Description,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Categories.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new CategoryDto(entity.Id, entity.Name, entity.Description);
    }
}
