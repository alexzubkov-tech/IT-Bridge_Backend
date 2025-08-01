﻿using CoreService.Application.Answers.Dtos;
using CoreService.Application.Categories.Dtos;
using CoreService.Application.CommentQuestions.Dtos;
using CoreService.Application.Questions.Dtos;
using CoreService.Application.RatingQuestions.Dtos;
using CoreService.Application.Tags.Dtos;
using CoreService.Application.UserProfile.Mapper;
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
                UpdatedAt = entity.UpdatedAt
            };
        }

        public static TagDetailsDto ToDetailsDto(this Tag entity)
        {
            return new TagDetailsDto
            {
                Id = entity.Id,
                Name = entity.Name,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                Questions = entity.QuestionTags
                    .Select(qt => new QuestionDto
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