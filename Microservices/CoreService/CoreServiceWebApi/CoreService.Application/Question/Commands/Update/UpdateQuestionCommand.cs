using Application.Questions.DTOs;
using CoreService.Application.Common.Interfaces;
using MediatR;

public record UpdateQuestionCommand(Guid Id, UpdateQuestionDto QuestionDto) : IRequest<QuestionDto>;

public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, QuestionDto>
{
    private readonly ICoreServiceDbContext _context;

    public UpdateQuestionCommandHandler(ICoreServiceDbContext context)
    {
        _context = context;
    }

    public async Task<QuestionDto> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Questions.FindAsync(new object?[] { request.Id }, cancellationToken);

        if (entity == null)
            throw new Exception("Question not found");

        entity.Title = request.QuestionDto.Title;
        entity.Content = request.QuestionDto.Content;
        entity.IsUrgent = request.QuestionDto.IsUrgent;
        entity.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        var profile = await _context.UserProfiles.FindAsync(new object?[] { entity.ProfileUserId }, cancellationToken);

        return new QuestionDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Content = entity.Content,
            IsUrgent = entity.IsUrgent,
            ViewCount = entity.ViewCount,
            CreatedAt = entity.CreatedAt,
            ProfileUserId = entity.ProfileUserId,
            ProfileUserName = profile?.FIO ?? "Unknown"
        };
    }
}