using CoreService.Application.Questions.Dtos;
using CoreService.Domain.Entities;

namespace CoreService.Application.Questions.Mapper
{
    public static class QuestionMapper
    {
        public static Question ToEntity(this CreateQuestionDto dto, int userProfileId)
        {
            return new Question
            {
                Title = dto.Title,
                Content = dto.Content,
                IsUrgent = dto.IsUrgent,
                UserProfileId = userProfileId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public static void UpdateEntityFromDto(this Question entity, UpdateQuestionDto dto)
        {
            entity.Title = dto.Title;
            entity.Content = dto.Content;
            entity.IsUrgent = dto.IsUrgent;
            entity.UpdatedAt = DateTime.UtcNow;
        }

        public static QuestionDto ToDto(this Question entity)
        {
            return new QuestionDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Content = entity.Content,
                IsUrgent = entity.IsUrgent,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                UserProfileId = entity.UserProfileId
            };
        }


    }
}