namespace CoreService.Application.Answers.Dtos
{
    public class UpdateAnswerDto
    {
        public string Content { get; set; }
        public int UserProfileId { get; set; }
        public int QuestionId { get; set; }
    }
}