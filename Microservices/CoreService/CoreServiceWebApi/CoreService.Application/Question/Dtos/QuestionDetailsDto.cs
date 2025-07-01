using CoreService.Application.Answers.Dtos;
using CoreService.Application.Categories.Dtos;
using CoreService.Application.CommentQuestions.Dtos;
using CoreService.Application.RatingQuestions.Dtos;
using CoreService.Application.Tags.Dtos;
using CoreService.Application.UserProfiles.Dtos;

namespace CoreService.Application.Questions.Dtos
{
    public class QuestionDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public bool IsUrgent { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int RatingPositive { get; set; } = 0;
        public int RatingNegative { get; set; } = 0;

        public int UserProfileId { get; set; }
        public UserProfileDto Author { get; set; }

        public List<AnswerDto> Answers { get; set; } = new();
        public List<CommentQuestionDto> Comments { get; set; } = new();
        public List<RatingQuestionDto> Ratings { get; set; } = new();
        public List<TagDto> Tags { get; set; } = new();
        public List<CategoryDto> Categories { get; set; } = new();
    }
}
