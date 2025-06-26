namespace CoreService.Domain.Entities
{
    public class UserProfile
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; }
        public string FIO { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public bool IsExpert { get; set; }
        public string? GitHubUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? ResumeUrl { get; set; }
        public Guid? CompanyId { get; set; }
        public Company? Company { get; set; }

        // вроеде PositionId должен быть int для того чтобы Enum использовать
        public int PositionId { get; set; } 
        public int ExperienceYears { get; set; }
        public string? TelegramId { get; set; }

        public List<Question> Questions { get; set; } = new();
        public List<Answer> Answers { get; set; } = new();
        public List<CommentQuestion> QuestionComments { get; set; } = new();
        public List<CommentAnswer> AnswerComments { get; set; } = new();
        public List<QuestionRating> QuestionRatings { get; set; } = new();
        public List<AnswerRating> AnswerRatings { get; set; } = new();

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public UserProfile() { }

        public UserProfile(string email, string fio, string bio, bool isExpert)
        {
            Id = Guid.NewGuid();
            Email = email;
            FIO = fio;
            Bio = bio;
            IsExpert = isExpert;
            CreatedAt = UpdatedAt = DateTime.UtcNow;
        }
    }
}
