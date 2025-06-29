namespace CoreService.Application.CommentAnswers.Dtos
{
    public class CommentAnswerDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int UserProfileId { get; set; }
        public int AnswerId { get; set; }
    }
}