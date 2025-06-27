
namespace CoreService.Application.UserProfiles.Dtos
{
    public class CreateUserProfileDto
    {
        public bool IsExpert { get; set; } = false;
        public string FIO { get; set; }
        public string Bio { get; set; } = string.Empty;
        public string GithubUrl { get; set; } = string.Empty;
        public string LinkedinUrl { get; set; } = string.Empty;
        public string TelegramId { get; set; } = string.Empty;
        public string ResumeLink { get; set; } = string.Empty;
        public int? ExperienceYears { get; set; }
        public Position Position { get; set; }
        public int? CompanyId { get; set; }
        public int? CategoryId { get; set; }
    }
}
