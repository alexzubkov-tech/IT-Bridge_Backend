using CoreService.Domain.Entities;
using CoreService.Application.RatingAnswers.Dtos;

namespace CoreService.Application.RatingAnswers.Mapper
{
    public static class RatingAnswerMapper
    {
        public static RatingAnswer ToEntity(this CreateRatingAnswerDto dto)
        {
            return new RatingAnswer
            {
                IsGoodAnswer = dto.IsGoodAnswer,
                UserProfileId = dto.UserProfileId,
                AnswerId = dto.AnswerId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public static void UpdateEntityFromDto(this RatingAnswer entity, UpdateRatingAnswerDto dto)
        {
            entity.IsGoodAnswer = dto.IsGoodAnswer;
            entity.UserProfileId = dto.UserProfileId;
            entity.AnswerId = dto.AnswerId;
            entity.UpdatedAt = DateTime.UtcNow;
        }

        public static RatingAnswerDto ToDto(this RatingAnswer entity)
        {
            return new RatingAnswerDto
            {
                Id = entity.Id,
                IsGoodAnswer = entity.IsGoodAnswer,
                UpdatedAt = entity.UpdatedAt,
                UserProfileId = entity.UserProfileId,
                AnswerId = entity.AnswerId
            };
        }

        public static RatingToUserProfileDto ToUserRating(this IEnumerable<RatingAnswer> entity)
        {
            return new RatingToUserProfileDto
            {
                RatingPositive = entity.Count(rn => rn.IsGoodAnswer),
                RatingNegative = entity.Count(rn => !rn.IsGoodAnswer),
            };
        }
    }
}