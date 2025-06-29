namespace CoreService.Application.Questions.Dtos
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public bool IsUrgent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserProfileId { get; set; }
    }
}