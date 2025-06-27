using CoreService.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileByIdQuery, UserProfileDto>
{
    private readonly ICoreServiceDbContext _context;

    public GetUserProfileByIdQueryHandler(ICoreServiceDbContext context)
    {
        _context = context;
    }

    public async Task<UserProfileDto> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Include(u => u.UserProfile)
            .ThenInclude(p => p.Company)
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null)
            throw new Exception("User not found");

        var profile = user.UserProfile;

        return new UserProfileDto
        {
            Id = profile.Id,
            UserName = profile.UserName,
            FIO = profile.FIO,
            Bio = profile.Bio,
            IsExpert = profile.IsExpert,
            GitHubUrl = profile.GitHubUrl,
            LinkedInUrl = profile.LinkedInUrl,
            ResumeUrl = profile.ResumeUrl,
            CompanyId = profile.CompanyId,
            CompanyName = profile.Company?.Name,
            PositionId = profile.PositionId,
            ExperienceYears = profile.ExperienceYears,
            Email = profile.Email,
            CreatedAt = profile.CreatedAt,
            UpdatedAt = profile.UpdatedAt
        };
    }
}
