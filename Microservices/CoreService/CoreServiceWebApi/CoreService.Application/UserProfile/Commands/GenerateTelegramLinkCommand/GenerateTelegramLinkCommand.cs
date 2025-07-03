using MediatR;

namespace CoreService.Application.UserProfile.Commands.GenerateTelegramLinkCommand
{
    public class GenerateTelegramLinkCommand : IRequest<string>
    {
        public int UserProfileId { get; set; }
    }
}
