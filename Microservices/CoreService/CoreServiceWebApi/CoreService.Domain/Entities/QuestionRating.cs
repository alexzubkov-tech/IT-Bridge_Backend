namespace CoreService.Domain.Entities
{
    public class QuestionRating
    {
        public Guid Id { get; set; }
        public Guid ProfileUserId { get; set; }
        public UserProfile ProfileUser { get; set; } = null!;
        public Guid QuestionId { get; set; }
        public Question Question { get; set; } = null!;
        public bool IsGoodQuestion { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public QuestionRating() { }

        public QuestionRating(Guid profileUserId, Guid questionId, bool isGood)
        {
            Id = Guid.NewGuid();
            ProfileUserId = profileUserId;
            QuestionId = questionId;
            IsGoodQuestion = isGood;
            CreatedAt = UpdatedAt = DateTime.UtcNow;
        }
    }
}
