using Application.Questions.DTOs;
using CoreService.Application.Common.Interfaces;
using CoreService.Domain.Entities;
using MediatR;

namespace Application.Questions.Commands
{
    public record CreateQuestionCommand(CreateQuestionDto QuestionDto) : IRequest<QuestionDto>;

    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, QuestionDto>
    {
        private readonly ICoreServiceDbContext _context;

        public CreateQuestionCommandHandler(ICoreServiceDbContext context)
        {
            _context = context;
        }

        public async Task<QuestionDto> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var entity = new Question(
                request.QuestionDto.Title,
                request.QuestionDto.Content,
                request.QuestionDto.ProfileUserId,
                request.QuestionDto.IsUrgent
            );

            _context.Questions.Add(entity);
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
}