using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.UserProfile.Commands.GenerateTelegramLinkCommand
{
    public class GenerateTelegramLinkCommandHandler : IRequestHandler<GenerateTelegramLinkCommand, string>
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public GenerateTelegramLinkCommandHandler(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<string> Handle(GenerateTelegramLinkCommand request, CancellationToken cancellationToken)
        {
            var profile = await _userProfileRepository.GetByIdAsync(request.UserProfileId);
            if (profile == null)
                throw new KeyNotFoundException("User profile not found");
            if (!profile.IsExpert)
                throw new InvalidOperationException("User is not an expert");

            string botUsername = "ItMostNotification_bot"; // Замени на имя бота или возьми из конфигурации
            return $"t.me/{botUsername}?start={profile.Id}_{profile.CategoryId}";
        }
    }
}
