namespace CoreService.Application.RatingQuestions.Dtos
{
    public class RatingQuestionDto
    {
        public int Id { get; set; }
        public bool IsGoodAnswer { get; set; }
        public int UserProfileId { get; set; }
        public int QuestionId { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}