namespace CoreService.Application.CommentQuestions.Dtos
{
    public class CommentQuestionDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserProfileId { get; set; }
        public int QuestionId { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}