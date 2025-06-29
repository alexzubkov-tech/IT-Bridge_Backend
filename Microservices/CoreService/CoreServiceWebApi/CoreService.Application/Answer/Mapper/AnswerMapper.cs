using CoreService.Domain.Entities;
using CoreService.Application.Answers.Dtos;

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
    }
}