using CoreService.Application.CommentAnswers.Dtos;
using CoreService.Application.RatingAnswers.Dtos;

namespace CoreService.Application.Answers.Dtos
{
    public class AnswerDetailsDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int RatingPositive { get; set; } = 0;
        public int RatingNegative { get; set; } = 0;

        public int UserProfileId { get; set; }
        public int QuestionId { get; set; }

        public List<CommentAnswerDto> Comments { get; set; } = new();
        public List<RatingAnswerDto> Ratings { get; set; } = new();
    }
}
