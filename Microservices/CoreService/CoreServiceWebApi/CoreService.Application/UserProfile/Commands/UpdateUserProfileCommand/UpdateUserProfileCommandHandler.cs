using CoreService.Application.UserProfiles.Dtos;
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

            var dto = request.Dto;
            profile.IsExpert = dto.IsExpert;
            profile.FIO = dto.FIO;
            profile.Bio = dto.Bio;
            profile.GithubUrl = dto.GithubUrl;
            profile.LinkedinUrl = dto.LinkedinUrl;
            profile.TelegramId = dto.TelegramId;
            profile.ResumeLink = dto.ResumeLink;
            profile.ExperienceYears = dto.ExperienceYears;
            profile.Position = dto.Position;
            profile.CompanyId = dto.CompanyId;
            profile.CategoryId = dto.CategoryId;
            profile.UpdatedAt = DateTime.UtcNow;

            await _userProfileRepository.UpdateAsync(profile);

            return MapToDto(profile);
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
