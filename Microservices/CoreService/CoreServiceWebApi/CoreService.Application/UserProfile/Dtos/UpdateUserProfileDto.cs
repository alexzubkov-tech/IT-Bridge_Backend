namespace CoreService.Application.UserProfiles.Dtos
{
    public class UpdateUserProfileDto
    {
        public string FIO { get; set; }
        public string Bio { get; set; }
        public string GithubUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string ResumeLink { get; set; }
        public string TelegramId { get; set; }
        public int? ExperienceYears { get; set; }
        public bool IsExpert { get; set; }
        public Position Position { get; set; }

        public int? CompanyId { get; set; }
        public int? CategoryId { get; set; }
    }
}