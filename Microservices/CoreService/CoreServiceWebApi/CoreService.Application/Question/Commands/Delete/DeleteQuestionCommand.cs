using CoreService.Application.Common.Interfaces;
using MediatR;

public record DeleteQuestionCommand(Guid Id) : IRequest<bool>;

public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, bool>
{
    private readonly ICoreServiceDbContext _context;

    public DeleteQuestionCommandHandler(ICoreServiceDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Questions.FindAsync(new object?[] { request.Id }, cancellationToken);
        if (entity == null) return false;

        _context.Questions.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}