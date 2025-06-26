namespace CoreService.Domain.Entities
{
    public class AnswerRating
    {
        public Guid Id { get; set; }
        public Guid ProfileUserId { get; set; }
        public UserProfile ProfileUser { get; set; } = null!;
        public Guid AnswerId { get; set; }
        public Answer Answer { get; set; } = null!;
        public bool IsGoodAnswer { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public AnswerRating() { }

        public AnswerRating(Guid profileUserId, Guid answerId, bool isGood)
        {
            Id = Guid.NewGuid();
            ProfileUserId = profileUserId;
            AnswerId = answerId;
            IsGoodAnswer = isGood;
            CreatedAt = UpdatedAt = DateTime.UtcNow;
        }
    }
}
