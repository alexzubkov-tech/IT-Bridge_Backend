namespace CoreService.Domain.Entities
{
    public class CommentAnswer
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public Guid AnswerId { get; set; }
        public Answer Answer { get; set; } = null!;
        public Guid ProfileUserId { get; set; }
        public UserProfile ProfileUser { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public CommentAnswer() { }

        public CommentAnswer(string content, Guid answerId, Guid profileUserId)
        {
            Id = Guid.NewGuid();
            Content = content;
            AnswerId = answerId;
            ProfileUserId = profileUserId;
            CreatedAt = UpdatedAt = DateTime.UtcNow;
        }
    }
}
