namespace CoreService.Application.RatingAnswers.Dtos
{
    public class UpdateRatingAnswerDto
    {
        public bool IsGoodAnswer { get; set; }
        public int UserProfileId { get; set; }
        public int AnswerId { get; set; }
    }
}