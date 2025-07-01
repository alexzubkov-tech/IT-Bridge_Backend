using CoreService.Domain.Entities;
using CoreService.Application.CommentQuestions.Dtos;

namespace CoreService.Application.CommentQuestions.Mapper
{
    public static class CommentQuestionMapper
    {
        public static CommentQuestion ToEntity(this CreateCommentQuestionDto dto)
        {
            return new CommentQuestion
            {
                Content = dto.Content,
                UserProfileId = dto.UserProfileId,
                QuestionId = dto.QuestionId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public static void UpdateEntityFromDto(this CommentQuestion entity, UpdateCommentQuestionDto dto)
        {
            entity.Content = dto.Content;
            entity.UpdatedAt = DateTime.UtcNow;
        }

        public static CommentQuestionDto ToDto(this CommentQuestion entity)
        {
            return new CommentQuestionDto
            {
                Id = entity.Id,
                Content = entity.Content,
                UpdatedAt = entity.UpdatedAt,
                UserProfileId = entity.UserProfileId,
                QuestionId = entity.QuestionId
            };
        }
    }
}