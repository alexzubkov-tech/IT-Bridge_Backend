using CoreService.Application.UserProfiles.Dtos;
using CoreService.Application.UserProfile.Mapper;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.UserProfiles.Commands.CreateUserProfileCommand
{
    public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, UserProfileDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly ILogger<CreateUserProfileCommandHandler> _logger;

        public CreateUserProfileCommandHandler(
            UserManager<User> userManager,
            IUserProfileRepository userProfileRepository,
            ILogger<CreateUserProfileCommandHandler> logger)
        {
            _userManager = userManager;
            _userProfileRepository = userProfileRepository;
            _logger = logger;
        }

        public async Task<UserProfileDto> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user == null)
                    throw new KeyNotFoundException("User not found");

                var profile = request.Dto.ToEntity(user.Id);
                await _userProfileRepository.CreateAsync(profile);

                return profile.ToDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user profile.");
                throw; 
            }
        }
    }
}
