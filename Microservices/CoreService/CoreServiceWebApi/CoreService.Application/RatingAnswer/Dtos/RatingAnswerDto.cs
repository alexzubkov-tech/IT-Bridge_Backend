namespace CoreService.Application.RatingAnswers.Dtos
{
    public class RatingAnswerDto
    {
        public int Id { get; set; }
        public bool IsGoodAnswer { get; set; }
        public int UserProfileId { get; set; }
        public int AnswerId { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}