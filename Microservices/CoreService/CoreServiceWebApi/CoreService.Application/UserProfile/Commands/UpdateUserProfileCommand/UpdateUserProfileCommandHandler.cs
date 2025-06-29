using CoreService.Application.UserProfiles.Dtos;
using CoreService.Application.UserProfiles.Mapper;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CoreService.Application.UserProfiles.Commands.UpdateUserProfileCommand
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UserProfileDto>
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UpdateUserProfileCommandHandler(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<UserProfileDto> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = await _userProfileRepository.GetByIdAsync(request.Id);
            if (profile == null)
                throw new KeyNotFoundException("User profile not found");

            profile.UpdateEntityFromDto(request.Dto);

            await _userProfileRepository.UpdateAsync(profile);

            return profile.ToDto();
        }
    }
}
