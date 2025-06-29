using CoreService.Application.Categories.Dtos;
using CoreService.Application.Categories.Mapper;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.Categories.Queries.GetCategoryByIdQuery
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryWithProfilesDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryWithProfilesDto> Handle(GetCategoryByIdQuery request, CancellationToken ct)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if (category == null)
                throw new KeyNotFoundException("Category not found");

            return category.ToWithProfilesDto();
        }
    }
}