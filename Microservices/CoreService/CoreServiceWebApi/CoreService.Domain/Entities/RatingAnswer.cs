namespace CoreService.Entities
{
    public class RatingAnswer
    {
        public int Id { get; set; }
        public bool IsGoodAnswer { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}

