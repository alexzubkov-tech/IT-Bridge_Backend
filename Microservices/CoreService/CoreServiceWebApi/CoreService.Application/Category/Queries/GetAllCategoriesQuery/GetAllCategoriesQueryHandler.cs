using CoreService.Application.Categories.Dtos;
using CoreService.Application.Categories.Mapper;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.Categories.Queries.GetAllCategoriesQuery
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken ct)
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(c => c.ToDto());
        }
    }
}