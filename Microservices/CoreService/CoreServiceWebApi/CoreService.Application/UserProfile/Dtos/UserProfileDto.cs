public class UserProfileDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string FIO { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public bool IsExpert { get; set; }

    public string? GitHubUrl { get; set; }
    public string? LinkedInUrl { get; set; }
    public string? ResumeUrl { get; set; }

    public Guid? CompanyId { get; set; }
    public string? CompanyName { get; set; }

    public int PositionId { get; set; }
    public int ExperienceYears { get; set; }

    public string Email { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
