using CoreService.Application.Tags.Dtos;
using CoreService.Domain.Entities;

namespace CoreService.Application.Tags.Mapper
{
    public static class TagMapper
    {
        public static Tag ToEntity(this CreateTagDto dto)
        {
            return new Tag
            {
                Name = dto.Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public static void UpdateEntityFromDto(this Tag entity, UpdateTagDto dto)
        {
            entity.Name = dto.Name;
            entity.UpdatedAt = DateTime.UtcNow;
        }

        public static TagDto ToDto(this Tag entity)
        {
            return new TagDto
            {
                Id = entity.Id,
                Name = entity.Name,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }

        public static TagWithQuestionsDto ToTagWithQuestionsDto(this Tag entity)
        {
            return new TagWithQuestionsDto
            {
                Id = entity.Id,
                Name = entity.Name,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                Questions = entity.QuestionTags
                    .Select(qt => new QuestionInTagDto
                    {
                        Id = qt.Question.Id,
                        Title = qt.Question.Title,
                        Content = qt.Question.Content,
                        IsUrgent = qt.Question.IsUrgent,
                        CreatedAt = qt.Question.CreatedAt,
                        UserProfileId = qt.Question.UserProfileId
                    })
                    .ToList()
            };
        }
    }
}