using Application.Questions.DTOs;
using CoreService.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record GetQuestionByIdQuery(Guid Id) : IRequest<QuestionDto>;

public class GetQuestionByIdQueryHandler : IRequestHandler<GetQuestionByIdQuery, QuestionDto>
{
    private readonly ICoreServiceDbContext _context;

    public GetQuestionByIdQueryHandler(ICoreServiceDbContext context)
    {
        _context = context;
    }

    public async Task<QuestionDto> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Questions
            .Include(q => q.ProfileUser)
            .FirstOrDefaultAsync(q => q.Id == request.Id, cancellationToken);

        if (entity == null) throw new Exception("Question not found");

        return new QuestionDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Content = entity.Content,
            IsUrgent = entity.IsUrgent,
            ViewCount = entity.ViewCount,
            CreatedAt = entity.CreatedAt,
            ProfileUserId = entity.ProfileUserId,
            ProfileUserName = entity.ProfileUser.FIO
        };
    }
}