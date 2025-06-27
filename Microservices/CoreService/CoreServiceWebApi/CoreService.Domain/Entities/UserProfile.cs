using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CoreService.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }
        public bool IsExpert { get; set; } = false;
        public string FIO { get; set; }
        public string Bio { get; set; } = string.Empty;
        public string GithubUrl { get; set; } = string.Empty;
        public string LinkedinUrl { get; set; } = string.Empty;
        public string TelegramId { get; set; } = string.Empty;
        public string ResumeLink { get; set; } = string.Empty;
        public int? ExperienceYears { get; set; }
        public Position Position { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Question> Questions { get; set; } = new List<Question>();
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();

        public ICollection<RatingQuestion> RatingQuestions { get; set; } = new List<RatingQuestion>();
        public ICollection<RatingAnswer> RatingAnswers { get; set; } = new List<RatingAnswer>();

        public ICollection<CommentQuestion> CommentQuestions { get; set; } = new List<CommentQuestion>();
        public ICollection<CommentAnswer> CommentAnswers { get; set; } = new List<CommentAnswer>();
    }
}

public enum Position
{
    Junior = 1,
    Middle = 2,
    Senior = 3,
}