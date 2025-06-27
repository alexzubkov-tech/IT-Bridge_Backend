namespace CoreService.Entities
{
    public class QuestionCategory
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
