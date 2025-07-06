using CoreService.Application.RatingAnswers.Mapper;
using CoreService.Application.UserProfiles.Dtos;
using CoreService.Application.UserProfile.Mapper;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.UserProfiles.Queries.GetUserProfileByIdQuery
{
    public class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileByIdQuery, UserProfileDetaisDto>
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IRatingAnswerRepository _ratingAnswerRepository;

        public GetUserProfileByIdQueryHandler(IUserProfileRepository userProfileRepository, IRatingAnswerRepository ratingAnswerRepository)
        {
            _userProfileRepository = userProfileRepository;
            _ratingAnswerRepository = ratingAnswerRepository;
        }

        public async Task<UserProfileDetaisDto> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var profile = await _userProfileRepository.GetByIdAsync(request.Id);
            if (profile == null)
                throw new KeyNotFoundException("User profile not found");

            var rating = await _ratingAnswerRepository.GetAllRatingAnswerToUserProfileAsync(request.Id);

            var profileDto = profile.ToDetailsDto();
            var ratingToUser = rating.ToUserRating();

            profileDto.RatingPositive = ratingToUser.RatingPositive;
            profileDto.RatingNegative = ratingToUser.RatingNegative;

            return profileDto;
        }
    }
}
