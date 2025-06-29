namespace CoreService.Application.RatingQuestions.Dtos
{
    public class CreateRatingQuestionDto
    {
        public bool IsGoodAnswer { get; set; }
        public int UserProfileId { get; set; }
        public int QuestionId { get; set; }
    }
}