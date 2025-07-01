using CoreService.Application.CommentAnswers.Dtos;
using CoreService.Application.CommentQuestions.Dtos;
using CoreService.Application.RatingAnswers.Dtos;
using CoreService.Application.RatingQuestions.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreService.Application.Answers.Dtos
{
    public class AnswerDetailsDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int UserProfileId { get; set; }
        public int QuestionId { get; set; }

        public List<CommentAnswerDto> Comments { get; set; } = new();
        public List<RatingAnswerDto> Ratings { get; set; } = new();
    }
}
