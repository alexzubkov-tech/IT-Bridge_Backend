namespace CoreService.Domain.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public ICollection<RatingAnswer> RatingAnswers { get; set; } = new List<RatingAnswer>();
        public ICollection<CommentAnswer> CommentAnswers { get; set; } = new List<CommentAnswer>();
    }
}
