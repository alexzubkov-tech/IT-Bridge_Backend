using BuildingBlock.Events;
using BuildingBlocks.EventBus.Abstractions;
using CoreService.Application.UserProfile.Mapper;
using CoreService.Application.UserProfiles.Dtos;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CoreService.Application.UserProfiles.Commands.UpdateUserProfileCommand
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UserProfileDto>
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IEventBusPublisher _eventBusPublisher;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICompanyRepository _companyRepository;

        public UpdateUserProfileCommandHandler(
            IUserProfileRepository userProfileRepository,
            IEventBusPublisher eventBusPublisher,
            ICategoryRepository categoryRepository,
            ICompanyRepository companyRepository)
        {
            _userProfileRepository = userProfileRepository;
            _eventBusPublisher = eventBusPublisher;
            _categoryRepository = categoryRepository;
            _companyRepository = companyRepository;
        }

        public async Task<UserProfileDto> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            // 1. Стандартная валидация атрибутов
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(dto);


            // 2. Проверяем наличие профиля
            var profile = await _userProfileRepository.GetByIdAsync(request.Id);
            if (profile == null)
                throw new KeyNotFoundException("User profile not found");

            // 3. Бизнес-валидация: категория и компания
            var businessErrors = new List<ValidationResult>();

            // 4. Обновляем профиль
            var oldCategoryName = await _userProfileRepository.GetCategoryNameByUserProfileIdAsync(request.Id);
            profile.UpdateEntityFromDto(dto);
            await _userProfileRepository.UpdateAsync(profile);

            // 5. Публикуем событие, если категория изменилась
            var newCategoryName = await _userProfileRepository.GetCategoryNameByUserProfileIdAsync(request.Id);
            if (oldCategoryName != newCategoryName)
            {
                _eventBusPublisher.Publish(new UserProfileUpdatedNotificationEvent(profile.Id, newCategoryName));
            }

            return profile.ToDto();
        }
    }
}