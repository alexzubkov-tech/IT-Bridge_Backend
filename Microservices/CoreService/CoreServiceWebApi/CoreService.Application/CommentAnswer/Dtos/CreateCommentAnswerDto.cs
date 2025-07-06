namespace CoreService.Application.CommentAnswers.Dtos
{
    public class CreateCommentAnswerDto
    {
        public string Content { get; set; }
        public int UserProfileId { get; set; }
        public int AnswerId { get; set; }
    }
}