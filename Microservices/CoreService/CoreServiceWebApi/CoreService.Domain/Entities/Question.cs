namespace CoreService.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsUrgent { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();

        public ICollection<QuestionTag> QuestionTags { get; set; } = new List<QuestionTag>();
        public ICollection<QuestionCategory> QuestionCategories { get; set; } = new List<QuestionCategory>();

        public ICollection<RatingQuestion> RatingQuestions { get; set; } = new List<RatingQuestion>();
        public ICollection<CommentQuestion> CommentQuestions { get; set; } = new List<CommentQuestion>();
    }
}
