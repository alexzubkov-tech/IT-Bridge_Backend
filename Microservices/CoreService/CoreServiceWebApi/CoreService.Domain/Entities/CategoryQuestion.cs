namespace CoreService.Domain.Entities
{
    public class CategoryQuestion
    {
        public Guid QuestionId { get; set; }
        public Question Question { get; set; } = null!;
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public CategoryQuestion() { }

        public CategoryQuestion(Guid questionId, Guid categoryId)
        {
            QuestionId = questionId;
            CategoryId = categoryId;
            CreatedAt = UpdatedAt = DateTime.UtcNow;
        }
    }
}
