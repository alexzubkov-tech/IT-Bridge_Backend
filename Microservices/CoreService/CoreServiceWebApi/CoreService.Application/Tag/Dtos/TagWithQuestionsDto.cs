namespace CoreService.Application.Tags.Dtos
{
    public class TagWithQuestionsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<QuestionInTagDto> Questions { get; set; } = new List<QuestionInTagDto>();
    }

    public class QuestionInTagDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsUrgent { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserProfileId { get; set; }
    }
}