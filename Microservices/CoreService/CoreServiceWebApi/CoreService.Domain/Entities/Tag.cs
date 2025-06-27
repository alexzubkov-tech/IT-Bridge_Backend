namespace CoreService.Domain.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        
        public ICollection<QuestionTag> QuestionTags { get; set; } = new List<QuestionTag>();
    }
}
