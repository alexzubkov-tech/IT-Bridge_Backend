using CoreService.Application.Account.Dtos;
using CoreService.Application.UserProfiles.Mapper;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CoreService.Application.Account.Queries.GetUserFullInfoQuery
{
    public class GetUserFullInfoQueryHandler : IRequestHandler<GetUserFullInfoQuery, UserFullInfoDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserProfileRepository _userProfileRepository;

        public GetUserFullInfoQueryHandler(
            UserManager<User> userManager,
            IUserProfileRepository userProfileRepository)
        {
            _userManager = userManager;
            _userProfileRepository = userProfileRepository;
        }

        public async Task<UserFullInfoDto> Handle(GetUserFullInfoQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            var profile = await _userProfileRepository.GetByUserIdAsync(user.Id);
            if (profile == null)
                throw new KeyNotFoundException("User profile not found");

            return new UserFullInfoDto
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserProfile = profile.ToDto()
            };
        }
    }
}
