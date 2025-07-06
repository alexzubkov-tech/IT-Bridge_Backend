using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.UserProfiles.Commands.DeleteUserProfileCommand
{
    public class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommand, bool>
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public DeleteUserProfileCommandHandler(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<bool> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
        {
            return await _userProfileRepository.DeleteAsync(request.Id);
        }
    }
}
