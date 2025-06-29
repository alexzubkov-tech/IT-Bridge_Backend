using CoreService.Domain.Entities;
using CoreService.Application.CommentAnswers.Dtos;

namespace CoreService.Application.CommentAnswers.Mapper
{
    public static class CommentAnswerMapper
    {
        public static CommentAnswer ToEntity(this CreateCommentAnswerDto dto)
        {
            return new CommentAnswer
            {
                Content = dto.Content,
                UserProfileId = dto.UserProfileId,
                AnswerId = dto.AnswerId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public static void UpdateEntityFromDto(this CommentAnswer entity, UpdateCommentAnswerDto dto)
        {
            entity.Content = dto.Content;
            entity.UserProfileId = dto.UserProfileId;
            entity.AnswerId = dto.AnswerId;
            entity.UpdatedAt = DateTime.UtcNow;
        }

        public static CommentAnswerDto ToDto(this CommentAnswer entity)
        {
            return new CommentAnswerDto
            {
                Id = entity.Id,
                Content = entity.Content,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                UserProfileId = entity.UserProfileId,
                AnswerId = entity.AnswerId
            };
        }
    }
}