namespace CoreService.Application.Questions.Dtos
{
    public class CreateQuestionDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public bool IsUrgent { get; set; } = false;
        public List<int> CategoryIds { get; set; } = new();
        public List<int> TagIds { get; set; } = new();

    }
}