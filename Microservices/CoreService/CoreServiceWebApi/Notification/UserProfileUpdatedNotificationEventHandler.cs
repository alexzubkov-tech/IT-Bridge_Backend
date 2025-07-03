using BuildingBlock.Events;
using BuildingBlocks.EventBus.Abstractions;
using NotificationService.Application.Interfaces.Repositories;
using NotificationService.Domain.Entities;

namespace Notification
{
    public class UserProfileUpdatedNotificationEventHandler : IEventHandler<UserProfileUpdatedNotificationEvent>
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileUpdatedNotificationEventHandler(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task Handle(UserProfileUpdatedNotificationEvent @event)
        {
            // Проверяем, существует ли профиль
            var existingProfile = await _userProfileRepository.GetByUserProfileIdAsync(@event.UserProfileId);

            if (existingProfile == null)
            {
                // Создаем новую сущность UserProfile
                var userProfile = new UserProfile(
                    userProfileId: @event.UserProfileId,
                    chatId: null, // ChatId будет добавлен позже через /start
                    categoryName: @event.CategoryName
                );

                // Сохраняем в репозиторий
                await _userProfileRepository.CreateAsync(userProfile);
            }
            else
            {
                // Обновляем существующую сущность
                existingProfile.CategoryName = @event.CategoryName;
                // ChatId не трогаем, так как он может быть уже установлен через /start
                await _userProfileRepository.UpdateAsync(existingProfile);
            }
        }
    }
}
