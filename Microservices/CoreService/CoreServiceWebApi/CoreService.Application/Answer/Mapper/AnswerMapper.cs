using CoreService.Application.Answers.Dtos;
using CoreService.Application.Categories.Dtos;
using CoreService.Application.CommentAnswers.Dtos;
using CoreService.Application.CommentQuestions.Dtos;
using CoreService.Application.Questions.Dtos;
using CoreService.Application.RatingAnswers.Dtos;
using CoreService.Application.RatingQuestions.Dtos;
using CoreService.Application.Tags.Dtos;
using CoreService.Application.UserProfile.Mapper;
using CoreService.Domain.Entities;

namespace CoreService.Application.Answers.Mapper
{
    public static class AnswerMapper
    {
        public static Answer ToEntity(this CreateAnswerDto dto)
        {
            return new Answer
            {
                Content = dto.Content,
                UserProfileId = dto.UserProfileId,
                QuestionId = dto.QuestionId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public static void UpdateEntityFromDto(this Answer entity, UpdateAnswerDto dto)
        {
            entity.Content = dto.Content;
            entity.UserProfileId = dto.UserProfileId;
            entity.QuestionId = dto.QuestionId;
            entity.UpdatedAt = DateTime.UtcNow;
        }

        public static AnswerDto ToDto(this Answer entity)
        {
            return new AnswerDto
            {
                Id = entity.Id,
                Content = entity.Content,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                UserProfileId = entity.UserProfileId,
                QuestionId = entity.QuestionId
            };
        }

        public static AnswerDetailsDto ToDetailsDto(this Answer entity)
        {
            return new AnswerDetailsDto
            {
                Id = entity.Id,
                Content = entity.Content,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                UserProfileId = entity.UserProfileId,
                QuestionId = entity.QuestionId,

                Comments = entity.CommentAnswers
                    .Select(c => new CommentAnswerDto
                    {
                        Id = c.Id,
                        Content = c.Content,
                    }).ToList(),

                Ratings = entity.RatingAnswers
                    .Select(r => new RatingAnswerDto
                    {
                        Id = r.Id,
                        IsGoodAnswer = r.IsGoodAnswer,
                    }).ToList(),

            };
        }
    }
}