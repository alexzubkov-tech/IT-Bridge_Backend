using CoreService.Application.Answers.Dtos;
using CoreService.Application.Categories.Dtos;
using CoreService.Application.CommentQuestions.Dtos;
using CoreService.Application.Questions.Dtos;
using CoreService.Application.RatingQuestions.Dtos;
using CoreService.Application.Tags.Dtos;
using CoreService.Application.UserProfiles.Dtos;
using CoreService.Application.UserProfiles.Mapper;
using CoreService.Domain.Entities;

namespace CoreService.Application.Questions.Mapper
{
    public static class QuestionMapper
    {
        public static Question ToEntity(this CreateQuestionDto dto, int userProfileId)
        {
            var question = new Question
            {
                Title = dto.Title,
                Content = dto.Content,
                IsUrgent = dto.IsUrgent,
                UserProfileId = userProfileId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            foreach (var categoryId in dto.CategoryIds)
            {
                question.QuestionCategories.Add(new QuestionCategory
                {
                    CategoryId = categoryId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });
            }

            foreach (var tagId in dto.TagIds)
            {
                question.QuestionTags.Add(new QuestionTag
                {
                    TagId = tagId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });
            }

            return question;
        }

        public static void UpdateEntityFromDto(this Question entity, UpdateQuestionDto dto)
        {
            entity.Title = dto.Title;
            entity.Content = dto.Content;
            entity.IsUrgent = dto.IsUrgent;
            entity.UpdatedAt = DateTime.UtcNow;

            entity.QuestionCategories.Clear();
            entity.QuestionTags.Clear();

            foreach (var categoryId in dto.CategoryIds)
            {
                entity.QuestionCategories.Add(new QuestionCategory
                {
                    CategoryId = categoryId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });
            }

            foreach (var tagId in dto.TagIds)
            {
                entity.QuestionTags.Add(new QuestionTag
                {
                    TagId = tagId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });
            }
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
                UserProfileId = entity.UserProfileId,

                Tags = entity.QuestionTags
                .Where(qt => qt.Tag != null)
                .Select(qt => new TagDto
                {
                    Id = qt.Tag!.Id,
                    Name = qt.Tag.Name,
                }).ToList(),

                Categories = entity.QuestionCategories
                .Where(qc => qc.Question != null)
                .Select(qc => new CategoryDto
                {
                    Id = qc.Category.Id,
                    Name = qc.Category.Name,
                    Description = qc.Category.Description,
                }).ToList(),
            };
        }

        public static QuestionDetailsDto ToDetailsDto(this Question question)
        {
            return new QuestionDetailsDto
            {
                Id = question.Id,
                Title = question.Title,
                Content = question.Content,
                IsUrgent = question.IsUrgent,
                UpdatedAt = question.UpdatedAt,

                Author = question.UserProfile?.ToDto() ?? throw new InvalidOperationException("Author is required"),

                Answers = question.Answers
                    .Where(a => a.UserProfile != null)
                    .Select(a => new AnswerDto
                    {
                        Id = a.Id,
                        Content = a.Content,
                        UserProfileId = a.UserProfile!.Id,
                    }).ToList(),

                Comments = question.CommentQuestions
                    .Where(c => c.UserProfile != null)
                    .Select(c => new CommentQuestionDto
                    {
                        Id = c.Id,
                        Content = c.Content,
                    }).ToList(),

                Ratings = question.RatingQuestions
                    .Where(r => r.UserProfile != null)
                    .Select(r => new RatingQuestionDto
                    {
                        Id = r.Id,
                        IsGoodAnswer = r.IsGoodAnswer,
                    }).ToList(),

                Tags = question.QuestionTags
                    .Where(qt => qt.Tag != null)
                    .Select(qt => new TagDto
                    {
                        Id = qt.Tag!.Id,
                        Name = qt.Tag.Name
                    }).ToList(),

                Categories = question.QuestionCategories
                    .Where(qc => qc.Category != null)
                    .Select(qc => new CategoryDto
                    {
                        Id = qc.Category!.Id,
                        Name = qc.Category.Name,
                        Description = qc.Category.Description,
                    }).ToList()
            };
        }
    }
}