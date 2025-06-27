using System;
using System.Collections.Generic;

namespace CoreService.Domain.Entities;

public class UserProfile
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
    public Company? Company { get; set; }
    public int PositionId { get; set; }
    public int ExperienceYears { get; set; }
    public string? TelegramId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Навигационные свойства
    public List<Question> Questions { get; set; } = new();
    public List<Answer> Answers { get; set; } = new();
    public List<CommentQuestion> QuestionComments { get; set; } = new();
    public List<CommentAnswer> AnswerComments { get; set; } = new();
    public List<QuestionRating> QuestionRatings { get; set; } = new();
    public List<AnswerRating> AnswerRatings { get; set; } = new();

    // Обратная навигация на User
    public User User { get; set; } = null!;

    public UserProfile() { }

    public UserProfile(string userName)
    {
        Id = Guid.NewGuid();
        UserName = userName;
        CreatedAt = UpdatedAt = DateTime.UtcNow;
    }
}