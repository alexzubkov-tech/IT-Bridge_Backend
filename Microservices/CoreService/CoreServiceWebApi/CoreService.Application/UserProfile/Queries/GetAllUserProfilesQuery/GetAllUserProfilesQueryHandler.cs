using CoreService.Application.UserProfiles.Dtos;
using CoreService.Application.UserProfile.Mapper;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.UserProfiles.Queries.GetAllUserProfilesQuery
{
    public class GetAllUserProfilesQueryHandler : IRequestHandler<GetAllUserProfilesQuery, List<UserProfileDto>>
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public GetAllUserProfilesQueryHandler(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<List<UserProfileDto>> Handle(GetAllUserProfilesQuery request, CancellationToken cancellationToken)
        {
            var profiles = await _userProfileRepository.GetAllAsync();
            return profiles.Select(p => p.ToDto()).ToList();
        }
    }
}
