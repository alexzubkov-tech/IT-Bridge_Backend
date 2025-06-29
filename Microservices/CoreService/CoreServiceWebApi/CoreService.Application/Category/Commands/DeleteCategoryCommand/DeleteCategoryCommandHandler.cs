using MediatR;
using CoreService.Domain.Interfaces;

namespace CoreService.Application.Categories.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken ct)
        {
            var result = await _categoryRepository.DeleteAsync(request.Id);
            if (!result)
                throw new KeyNotFoundException("Category not found");
            return result;
        }
    }
}