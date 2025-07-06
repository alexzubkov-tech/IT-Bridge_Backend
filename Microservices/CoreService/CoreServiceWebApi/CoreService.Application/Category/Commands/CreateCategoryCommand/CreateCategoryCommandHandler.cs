using CoreService.Application.Categories.Dtos;
using CoreService.Application.Categories.Mapper;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.Categories.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken ct)
        {
            var category = request.Dto.ToEntity();
            await _categoryRepository.CreateAsync(category);
            return category.ToDto();
        }
    }
}