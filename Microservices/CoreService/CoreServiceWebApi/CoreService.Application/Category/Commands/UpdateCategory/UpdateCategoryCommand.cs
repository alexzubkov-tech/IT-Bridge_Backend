//using Application.Categories.DTOs;
//using CoreService.Application.Common.Interfaces;
//using MediatR;

//namespace Application.Categories.Commands;

//public record UpdateCategoryCommand(Guid Id, UpdateCategoryDto CategoryDto) : IRequest<CategoryDto>;

//public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
//{
//    private readonly ICoreServiceDbContext _context;

//    public UpdateCategoryCommandHandler(ICoreServiceDbContext context)
//    {
//        _context = context;
//    }

//    public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
//    {
//        var category = await _context.Categories.FindAsync(new object[] { request.Id }, cancellationToken);

//        if (category == null)
//            throw new Exception($"Категория с id {request.Id} не найдена");

//        category.Name = request.CategoryDto.Name;
//        category.Description = request.CategoryDto.Description;
//        category.UpdatedAt = DateTime.UtcNow;

//        await _context.SaveChangesAsync(cancellationToken);

//        return new CategoryDto(category.Id, category.Name, category.Description);
//    }
//}
