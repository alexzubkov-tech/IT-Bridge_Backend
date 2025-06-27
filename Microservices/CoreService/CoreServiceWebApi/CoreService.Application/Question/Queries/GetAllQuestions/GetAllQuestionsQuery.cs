using Application.Questions.DTOs;
using CoreService.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Questions.Queries
{
    public record GetAllQuestionsQuery : IRequest<List<QuestionDto>>;

    public class GetAllQuestionsQueryHandler : IRequestHandler<GetAllQuestionsQuery, List<QuestionDto>>
    {
        private readonly ICoreServiceDbContext _context;

        public GetAllQuestionsQueryHandler(ICoreServiceDbContext context)
        {
            _context = context;
        }

        public async Task<List<QuestionDto>> Handle(GetAllQuestionsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Questions
                .Include(q => q.ProfileUser)
                .OrderByDescending(q => q.CreatedAt)
                .Select(q => new QuestionDto
                {
                    Id = q.Id,
                    Title = q.Title,
                    Content = q.Content,
                    IsUrgent = q.IsUrgent,
                    ViewCount = q.ViewCount,
                    CreatedAt = q.CreatedAt,
                    ProfileUserId = q.ProfileUserId,
                    ProfileUserName = q.ProfileUser.FIO
                })
                .ToListAsync(cancellationToken);
        }
    }
}