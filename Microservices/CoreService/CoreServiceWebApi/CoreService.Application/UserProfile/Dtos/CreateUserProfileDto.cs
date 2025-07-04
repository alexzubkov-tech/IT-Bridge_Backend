using System.ComponentModel.DataAnnotations;

namespace CoreService.Application.UserProfiles.Dtos
{
    public class CreateUserProfileDto
    {
        [Required(ErrorMessage = "FIO is required.")]
        [MinLength(2, ErrorMessage = "FIO must be at least 2 characters.")]
        [MaxLength(200, ErrorMessage = "FIO cannot exceed 200 characters.")]
        public string FIO { get; set; }

        [MaxLength(500, ErrorMessage = "Bio cannot exceed 500 characters.")]
        public string Bio { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = "TelegramId cannot exceed 100 characters.")]
        public string TelegramId { get; set; } = string.Empty;

        [UrlIfNotEmpty("GithubUrl must be a valid URL.")]
        public string GithubUrl { get; set; } = string.Empty;

        [UrlIfNotEmpty("LinkedinUrl must be a valid URL.")]
        public string LinkedinUrl { get; set; } = string.Empty;

        [UrlIfNotEmpty("ResumeLink must be a valid URL.")]
        public string ResumeLink { get; set; } = string.Empty;

        [Range(0, 100, ErrorMessage = "ExperienceYears must be between 0 and 100.")]
        public int? ExperienceYears { get; set; }

        [Required(ErrorMessage = "Position is required.")]
        public Position Position { get; set; }

        public int? CompanyId { get; set; }

        public int? CategoryId { get; set; }

        public bool IsExpert { get; set; } = false;
    }
}