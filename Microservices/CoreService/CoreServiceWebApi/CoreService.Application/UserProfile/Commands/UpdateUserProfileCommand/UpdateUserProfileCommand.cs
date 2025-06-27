using MediatR;

namespace CoreService.Application.UserProfiles.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommand : IRequest<Unit>
    {
        public Guid UserId { get; set; } // или брать из JWT позже
        public string UserName { get; set; } = string.Empty;
        public string FIO { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public bool IsExpert { get; set; }

        // Студент
        public string? ResumeUrl { get; set; }

        // Эксперт
        public string? GitHubUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public Guid? CompanyId { get; set; }
        public int? PositionId { get; set; }
        public int? ExperienceYears { get; set; }
    }
}
