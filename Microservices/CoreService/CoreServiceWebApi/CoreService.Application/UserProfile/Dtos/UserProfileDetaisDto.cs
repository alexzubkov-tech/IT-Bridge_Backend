using CoreService.Application.Answers.Dtos;
using CoreService.Application.Categories.Dtos;
using CoreService.Application.CommentAnswers.Dtos;
using CoreService.Application.CommentQuestions.Dtos;
using CoreService.Application.Companies.Dtos;
using CoreService.Application.Questions.Dtos;
using CoreService.Application.RatingAnswers.Dtos;
using CoreService.Application.RatingQuestions.Dtos;
using CoreService.Domain.Entities;


namespace CoreService.Application.UserProfiles.Dtos
{
    public class UserProfileDetaisDto
    {
        public int Id { get; set; }
        public bool IsExpert { get; set; }
        public string FIO { get; set; }
        public string Bio { get; set; }
        public string GithubUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string TelegramId { get; set; }
        public string ResumeLink { get; set; }
        public int? ExperienceYears { get; set; }
        public Position Position { get; set; }

        public int? CompanyId { get; set; }
        public CompanyDto Company { get; set; }


        public int? CategoryId { get; set; }
        public CategoryDto Category { get; set; }

        public string UserId { get; set; }

        public int RatingPositive { get; set; } = 0;
        public int RatingNegative { get; set; } = 0;

        public List<QuestionDto> Questions { get; set; } = new();
        public List<AnswerDto> Answers { get; set; } = new();

        public List<RatingQuestionDto> RatingQuestions { get; set; } = new();
        public List<RatingAnswerDto> RatingAnswers { get; set; } = new();

        public List<CommentQuestionDto> CommentQuestions { get; set; } = new();
        public List<CommentAnswerDto> CommentAnswers { get; set; } = new();

    }
}
