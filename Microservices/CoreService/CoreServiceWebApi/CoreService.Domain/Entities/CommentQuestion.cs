namespace CoreService.Domain.Entities
{
    public class CommentQuestion
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
