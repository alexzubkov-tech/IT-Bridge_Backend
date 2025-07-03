using BuildingBlock.Events;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.Events;
using Notification;

namespace NotificationService
{
    public static class EventBusExtension
    {
        public static void SubscribeToEvents(IServiceProvider serviceProvider)
        {
            var eventBus = serviceProvider.GetRequiredService<IEventBus>();
            eventBus.Subscribe<QuestionCreatedNotificationEvent, QuestionCreatedEventHandler>();
            eventBus.Subscribe<UserProfileUpdatedNotificationEvent, UserProfileUpdatedNotificationEventHandler>();
        }
    }
}