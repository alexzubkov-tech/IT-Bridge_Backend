using CoreService.Application.Questions.Dtos;
namespace CoreService.Application.RatingQuestions.Dtos
{
    public class RatingByQuestionDto
    {
        public int QuestionId { get; set; }
        public int RatingResult => RatingPositive - RatingNegative;
        public int RatingPositive { get; set; } = 0;
        public int RatingNegative { get; set; } = 0;
        public QuestionDetailsDto Question { get; set; } = null!;
    }
}