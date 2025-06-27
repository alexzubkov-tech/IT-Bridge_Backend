using MediatR;
using CoreService.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoreService.Application.UserProfiles.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, Unit>
    {
        private readonly ICoreServiceDbContext _context;

        public UpdateUserProfileCommandHandler(ICoreServiceDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .Include(u => u.UserProfile)
                .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (user == null)
                throw new Exception("User not found.");

            var profile = user.UserProfile;

            profile.FIO = request.FIO;
            profile.Bio = request.Bio;
            profile.IsExpert = request.IsExpert;
            profile.UserName = request.UserName;

            if (request.IsExpert)
            {
                profile.GitHubUrl = request.GitHubUrl;
                profile.LinkedInUrl = request.LinkedInUrl;
                profile.CompanyId = request.CompanyId;
                profile.PositionId = request.PositionId ?? 0;
                profile.ExperienceYears = request.ExperienceYears ?? 0;
                profile.ResumeUrl = null; // Очистим, если вдруг было
            }
            else
            {
                profile.ResumeUrl = request.ResumeUrl;
                profile.GitHubUrl = null;
                profile.LinkedInUrl = null;
                profile.CompanyId = null;
                profile.PositionId = 0;
                profile.ExperienceYears = 0;
            }

            profile.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
