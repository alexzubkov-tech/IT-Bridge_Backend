namespace CoreService.Entities
{
    public class CommentAnswer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}
