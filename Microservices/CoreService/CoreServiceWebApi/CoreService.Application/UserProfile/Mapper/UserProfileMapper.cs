
using CoreService.Application.Answers.Dtos;
using CoreService.Application.Categories.Mapper;
using CoreService.Application.CommentAnswers.Dtos;
using CoreService.Application.CommentQuestions.Dtos;
using CoreService.Application.Companies.Mapper;
using CoreService.Application.Questions.Dtos;
using CoreService.Application.RatingAnswers.Dtos;
using CoreService.Application.RatingQuestions.Dtos;
using CoreService.Application.UserProfiles.Dtos;
using CoreService.Domain.Entities;

namespace CoreService.Application.UserProfile.Mapper
{
    public static class UserProfileMapper
    {
        public static CoreService.Domain.Entities.UserProfile ToEntity(this CreateUserProfileDto dto, string userId)
        {
            return new CoreService.Domain.Entities.UserProfile
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

        public static void UpdateEntityFromDto(this CoreService.Domain.Entities.UserProfile entity, UpdateUserProfileDto dto)
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

        public static UserProfileDto ToDto(this CoreService.Domain.Entities.UserProfile entity)
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

        public static UserProfileDetaisDto ToDetailsDto(this CoreService.Domain.Entities.UserProfile entity)
        {
            return new UserProfileDetaisDto
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
                Company = entity.Company.ToDto(),

                CategoryId = entity.CategoryId,
                Category = entity.Category.ToDto(),

                UserId = entity.UserId,

                Answers = entity.Answers
                    .Select(a => new AnswerDto
                    {
                        Id = a.Id,
                        Content = a.Content,
                    }).ToList(),

                Questions = entity.Questions
                    .Select(c => new QuestionDto
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Content = c.Content,
                        IsUrgent = c.IsUrgent
                    }).ToList(),

                CommentAnswers = entity.CommentAnswers
                    .Select(r => new CommentAnswerDto
                    {
                        Id = r.Id,
                        Content = r.Content,
                    }).ToList(),

                CommentQuestions = entity.CommentQuestions
                    .Select(r => new CommentQuestionDto
                    {
                        Id = r.Id,
                        Content = r.Content,
                    }).ToList(),

                RatingAnswers = entity.RatingAnswers
                    .Select(r => new RatingAnswerDto
                    {
                        Id = r.Id,
                        IsGoodAnswer = r.IsGoodAnswer,
                    }).ToList(),

                RatingQuestions = entity.RatingQuestions
                    .Select(r => new RatingQuestionDto
                    {
                        Id = r.Id,
                        IsGoodAnswer = r.IsGoodAnswer,
                    }).ToList(),

            };
        }

        
    }
}
