using CoreService.Application.Categories.Dtos;
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
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }

        public static CategoryWithProfilesDto ToWithProfilesDto(this Category entity)
        {
            return new CategoryWithProfilesDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,

                UserProfiles = entity.UserProfiles.Select(up => new UserProfileDto
                {
                    Id = up.Id,
                    IsExpert = up.IsExpert,
                    FIO = up.FIO,
                    Bio = up.Bio,
                    GithubUrl = up.GithubUrl,
                    LinkedinUrl = up.LinkedinUrl,
                    TelegramId = up.TelegramId,
                    ResumeLink = up.ResumeLink,
                    ExperienceYears = up.ExperienceYears,
                    Position = up.Position,
                    CompanyId = up.CompanyId,
                    CategoryId = up.CategoryId,
                    UserId = up.UserId
                }).ToList()
            };
        }
    }
}