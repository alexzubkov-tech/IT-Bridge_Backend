
using CoreService.Application.UserProfiles.Dtos;
using CoreService.Domain.Entities;

namespace CoreService.Application.UserProfiles.Mapper
{
    public static class UserProfileMapper
    {
        public static UserProfile ToEntity(this CreateUserProfileDto dto, string userId)
        {
            return new UserProfile
            {
                IsExpert = dto.IsExpert,
                FIO = dto.FIO,
                Bio = dto.Bio,
                GithubUrl = dto.GithubUrl,
                LinkedinUrl = dto.LinkedinUrl,
                TelegramId = dto.TelegramId,
                ResumeLink = dto.ResumeLink,
                ExperienceYears = dto.ExperienceYears,
                Position = dto.Position,
                CompanyId = dto.CompanyId,
                CategoryId = dto.CategoryId,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public static void UpdateEntityFromDto(this UserProfile entity, UpdateUserProfileDto dto)
        {
            entity.IsExpert = dto.IsExpert;
            entity.FIO = dto.FIO;
            entity.Bio = dto.Bio;
            entity.GithubUrl = dto.GithubUrl;
            entity.LinkedinUrl = dto.LinkedinUrl;
            entity.TelegramId = dto.TelegramId;
            entity.ResumeLink = dto.ResumeLink;
            entity.ExperienceYears = dto.ExperienceYears;
            entity.Position = dto.Position;
            entity.CompanyId = dto.CompanyId;
            entity.CategoryId = dto.CategoryId;
            entity.UpdatedAt = DateTime.UtcNow;
        }

        public static UserProfileDto ToDto(this UserProfile entity)
        {
            return new UserProfileDto
            {
                Id = entity.Id,
                IsExpert = entity.IsExpert,
                FIO = entity.FIO,
                Bio = entity.Bio,
                GithubUrl = entity.GithubUrl,
                LinkedinUrl = entity.LinkedinUrl,
                TelegramId = entity.TelegramId,
                ResumeLink = entity.ResumeLink,
                ExperienceYears = entity.ExperienceYears,
                Position = entity.Position,
                CompanyId = entity.CompanyId,
                CategoryId = entity.CategoryId,
                UserId = entity.UserId
            };
        }
    }
}
