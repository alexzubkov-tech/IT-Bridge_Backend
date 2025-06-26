namespace CoreService.Domain.Entities
{
    public class Answer
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public Guid QuestionId { get; set; }
        public Question Question { get; set; } = null!;
        public Guid ProfileUserId { get; set; }
        public UserProfile ProfileUser { get; set; } = null!;

        public List<AnswerRating> Ratings { get; set; } = new();
        public List<CommentAnswer> Comments { get; set; } = new();

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Answer() { }

        public Answer(string content, Guid questionId, Guid profileUserId)
        {
            Id = Guid.NewGuid();
            Content = content;
            QuestionId = questionId;
            ProfileUserId = profileUserId;
            CreatedAt = UpdatedAt = DateTime.UtcNow;
        }
    }
}
