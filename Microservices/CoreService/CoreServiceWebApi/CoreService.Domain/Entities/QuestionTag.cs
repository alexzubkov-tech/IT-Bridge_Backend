namespace CoreService.Domain.Entities
{
    public class QuestionTag
    {
        public Guid QuestionId { get; set; }
        public Guid TagId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Question Question { get; set; }
        public Tag Tag { get; set; }

        public QuestionTag() { }

        public QuestionTag(Guid questionId, Guid tagId, DateTime createdAt, DateTime updatedAt)
        {
            QuestionId = questionId;
            TagId = tagId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
