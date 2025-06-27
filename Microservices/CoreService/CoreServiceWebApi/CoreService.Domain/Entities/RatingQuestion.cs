namespace CoreService.Entities
{
    public class RatingQuestion
    {
        public int Id { get; set; }
        public bool IsGoodAnswer { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
