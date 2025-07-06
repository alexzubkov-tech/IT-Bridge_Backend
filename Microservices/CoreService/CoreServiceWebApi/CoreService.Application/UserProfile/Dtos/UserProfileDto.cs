
namespace CoreService.Application.UserProfiles.Dtos
{
    public class UserProfileDto
    {
        public int Id { get; set; }
        public bool IsExpert { get; set; }
        public string FIO { get; set; }
        public string Bio { get; set; }
        public string GithubUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string TelegramId { get; set; }
        public string ResumeLink { get; set; }
        public int? ExperienceYears { get; set; }
        public Position Position { get; set; }
        public int? CompanyId { get; set; }
        public int? CategoryId { get; set; }

        public string UserId { get; set; }
    }
}
