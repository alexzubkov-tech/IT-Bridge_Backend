using CoreService.Application.UserProfiles.Dtos;
using CoreService.Application.UserProfiles.Mapper;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.UserProfiles.Queries.GetUserProfileByIdQuery
{
    public class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileByIdQuery, UserProfileDto>
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public GetUserProfileByIdQueryHandler(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<UserProfileDto> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var profile = await _userProfileRepository.GetByIdAsync(request.Id);
            if (profile == null)
                throw new KeyNotFoundException("User profile not found");

            return profile.ToDto();
        }
    }
}
