namespace CoreService.Domain.Entities
{
    public class UserProfile
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = string.Empty; // Для отображения
        public string Email { get; set; } = string.Empty;    // Копия Email из User
        public bool EmailConfirmed { get; set; }

        public string FIO { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public bool IsExpert { get; set; }
        public string? GitHubUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? ResumeUrl { get; set; }
        public Guid? CompanyId { get; set; }
        public Company? Company { get; set; }

        public int PositionId { get; set; }
        public int ExperienceYears { get; set; }
        public string? TelegramId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public UserProfile() { }

        public UserProfile(string email)
        {
            Id = Guid.NewGuid();
            Email = email;
            CreatedAt = UpdatedAt = DateTime.UtcNow;
        }
    }

}
