namespace CoreService.Application.Answers.Dtos
{
    public class AnswerWithUserInfoDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AuthorFIO { get; set; }
        public int UserProfileId { get; set; }
    }
}