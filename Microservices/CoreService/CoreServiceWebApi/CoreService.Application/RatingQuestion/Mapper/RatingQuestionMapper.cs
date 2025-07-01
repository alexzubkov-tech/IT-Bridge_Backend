using CoreService.Application.RatingQuestions.Dtos;
using CoreService.Domain.Entities;

namespace CoreService.Application.RatingQuestions.Mapper
{
    public static class RatingQuestionMapper
    {
        public static RatingQuestion ToEntity(this CreateRatingQuestionDto dto)
        {
            return new RatingQuestion
            {
                IsGoodAnswer = dto.IsGoodAnswer,
                UserProfileId = dto.UserProfileId,
                QuestionId = dto.QuestionId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public static void UpdateEntityFromDto(this RatingQuestion entity, UpdateRatingQuestionDto dto)
        {
            entity.IsGoodAnswer = dto.IsGoodAnswer;
            entity.UpdatedAt = DateTime.UtcNow;
        }

        public static RatingQuestionDto ToDto(this RatingQuestion entity)
        {
            return new RatingQuestionDto
            {
                Id = entity.Id,
                IsGoodAnswer = entity.IsGoodAnswer,
                UpdatedAt = entity.UpdatedAt,
                UserProfileId = entity.UserProfileId,
                QuestionId = entity.QuestionId
            };
        }
        public static RatingToQuestionDto ToQuestionRating(this IEnumerable<RatingQuestion> entity)
        {
            return new RatingToQuestionDto
            {
                RatingPositive = entity.Count(rn => rn.IsGoodAnswer),
                RatingNegative = entity.Count(rn => !rn.IsGoodAnswer),
            };
        }
    }
}