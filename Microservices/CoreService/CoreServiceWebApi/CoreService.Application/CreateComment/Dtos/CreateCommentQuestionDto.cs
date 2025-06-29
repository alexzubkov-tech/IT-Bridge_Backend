namespace CoreService.Application.CommentQuestions.Dtos
{
    public class CreateCommentQuestionDto
    {
        public string Content { get; set; }
        public int UserProfileId { get; set; }
        public int QuestionId { get; set; }
    }
}