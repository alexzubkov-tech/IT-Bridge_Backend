namespace CoreService.Application.Answers.Dtos
{
    public class AnswerDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int UserProfileId { get; set; }
        public int QuestionId { get; set; }
    }
}