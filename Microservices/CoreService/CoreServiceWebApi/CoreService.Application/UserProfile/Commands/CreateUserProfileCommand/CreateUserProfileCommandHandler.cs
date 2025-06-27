using CoreService.Application.UserProfiles.Dtos;
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

                var dto = request.Dto;
                var profile = new UserProfile
                {
                    UserId = user.Id,
                    IsExpert = dto.IsExpert,
                    FIO = dto.FIO,
                    Bio = dto.Bio,
                    GithubUrl = dto.GithubUrl,
                    LinkedinUrl = dto.LinkedinUrl,
                    TelegramId = dto.TelegramId,
                    ResumeLink = dto.ResumeLink,
                    ExperienceYears = dto.ExperienceYears,
                    Position = dto.Position,
                    CompanyId = dto.CompanyId,
                    CategoryId = dto.CategoryId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                await _userProfileRepository.CreateAsync(profile);

                return MapToDto(profile);
            }
            catch (Exception ex)
            {
                // Логируем исключение (например, через ILogger)
                _logger.LogError(ex, "Error creating user profile.");
                throw; // перебрасываем исключение дальше
            }
        }

        private static UserProfileDto MapToDto(UserProfile profile)
        {
            return new UserProfileDto
            {
                Id = profile.Id,
                IsExpert = profile.IsExpert,
                FIO = profile.FIO,
                Bio = profile.Bio,
                GithubUrl = profile.GithubUrl,
                LinkedinUrl = profile.LinkedinUrl,
                TelegramId = profile.TelegramId,
                ResumeLink = profile.ResumeLink,
                ExperienceYears = profile.ExperienceYears,
                Position = profile.Position,
                CompanyId = profile.CompanyId,
                CategoryId = profile.CategoryId,
                UserId = profile.UserId
            };
        }
    }
}
