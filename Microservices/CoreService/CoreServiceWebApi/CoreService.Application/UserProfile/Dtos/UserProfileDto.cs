namespace CoreService.Application.UserProfiles.Dtos;

public record UserProfileDto(
    Guid Id,
    string UserName,
    string FIO,
    string Bio,
    bool IsExpert,
    string? GitHubUrl,
    string? LinkedInUrl,
    string? ResumeUrl,
    Guid? CompanyId,
    string? CompanyName,
    int PositionId,
    int ExperienceYears,
    string? TelegramId,
    string Email,
    DateTime CreatedAt,
    DateTime UpdatedAt);