//using CoreService.Application.Common.Interfaces;
//using MediatR;
//using CoreService.Domain.Entities;

//namespace Application.Categories.Commands;

//public record DeleteCategoryCommand(Guid Id) : IRequest<bool>;

//public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
//{
//    private readonly ICoreServiceDbContext _context;

//    public DeleteCategoryCommandHandler(ICoreServiceDbContext context)
//    {
//        _context = context;
//    }

//    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
//    {
//        var category = await _context.Categories.FindAsync(new object[] { request.Id }, cancellationToken);

//        if (category == null)
//            return false;

//        _context.Categories.Remove(category);
//        await _context.SaveChangesAsync(cancellationToken);

//        return true;
//    }
//}
