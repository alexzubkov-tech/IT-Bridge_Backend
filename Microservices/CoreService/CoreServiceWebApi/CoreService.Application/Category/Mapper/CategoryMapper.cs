using CoreService.Application.Categories.Dtos;
using CoreService.Application.Questions.Dtos;
using CoreService.Application.UserProfiles.Dtos;
using CoreService.Domain.Entities;

namespace CoreService.Application.Categories.Mapper
{
    public static class CategoryMapper
    {
        public static Category ToEntity(this CreateCategoryDto dto)
        {
            return new Category
            {
                Name = dto.Name,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public static void UpdateEntityFromDto(this Category entity, UpdateCategoryDto dto)
        {
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.UpdatedAt = DateTime.UtcNow;
        }

        public static CategoryDto ToDto(this Category entity)
        {
            return new CategoryDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                UpdatedAt = entity.UpdatedAt
            };
        }
        public static CategoryDetailsDto ToDetailsDto(this Category entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return new CategoryDetailsDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,

                UserProfiles = entity.UserProfiles?
                    .Select(up => new UserProfileDto
                    {
                        Id = up.Id,
                        IsExpert = up.IsExpert,
                        FIO = up.FIO,
                        UserId = up.UserId,
                        CompanyId = up.CompanyId,
                        ExperienceYears = up.ExperienceYears,
                        Position = up.Position
                    })
                    .ToList() ?? new List<UserProfileDto>(),

                Questions = entity.QuestionCategories?
                    .Where(qc => qc.Question != null)
                    .Select(qc => new QuestionDto
                    {
                        Id = qc.Question.Id,
                        Title = qc.Question.Title,
                        Content = qc.Question.Content,
                        IsUrgent = qc.Question.IsUrgent,
                        CreatedAt = qc.Question.CreatedAt,
                        UpdatedAt = qc.Question.UpdatedAt
                    })
                    .ToList() ?? new List<QuestionDto>()
            };
        }
    }
}