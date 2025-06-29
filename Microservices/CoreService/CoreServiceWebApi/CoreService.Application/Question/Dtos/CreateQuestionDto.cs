namespace CoreService.Application.Questions.Dtos
{
    public class CreateQuestionDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public bool IsUrgent { get; set; } = false;
    }
}