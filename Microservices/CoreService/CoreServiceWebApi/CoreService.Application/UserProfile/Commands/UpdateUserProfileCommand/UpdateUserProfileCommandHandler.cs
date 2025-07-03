using BuildingBlock.Events;
using BuildingBlocks.EventBus.Abstractions;
using CoreService.Application.UserProfile.Mapper;
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
        private readonly IEventBusPublisher _eventBuspublisher;


        public UpdateUserProfileCommandHandler(IUserProfileRepository userProfileRepository, IEventBusPublisher eventBuspublisher)
        {
            _userProfileRepository = userProfileRepository;
            _eventBuspublisher = eventBuspublisher;
        }

        public async Task<UserProfileDto> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = await _userProfileRepository.GetByIdAsync(request.Id);
            if (profile == null)
                throw new KeyNotFoundException("User profile not found");

            var oldCategoryName = await _userProfileRepository.GetCategoryNameByUserProfileIdAsync(request.Id);

            profile.UpdateEntityFromDto(request.Dto);
            await _userProfileRepository.UpdateAsync(profile);

            var newCategoryName = await _userProfileRepository.GetCategoryNameByUserProfileIdAsync(request.Id);

            _eventBuspublisher.Publish(new UserProfileUpdatedNotificationEvent(profile.Id, newCategoryName));

            return profile.ToDto();
        }
    }
}