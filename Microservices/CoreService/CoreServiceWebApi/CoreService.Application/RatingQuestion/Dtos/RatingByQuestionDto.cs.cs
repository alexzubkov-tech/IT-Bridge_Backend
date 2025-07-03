namespace CoreService.Application.RatingQuestions.Dtos
{
    public class RatingByQuestionDto
    {
        public int QuestionId { get; set; }
        public int RatingPositive { get; set; } = 0;
        public int RatingNegative { get; set; } = 0;
        public int RatingResult => RatingPositive - RatingNegative;
    }
}