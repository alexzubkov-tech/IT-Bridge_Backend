using BuildingBlock.Events;
using BuildingBlocks.EventBus.Abstractions;
using NotificationService.EventHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace NotificationService
{
    public static class EventBusExtension
    {
        public static void SubscribeToEvents(IServiceProvider serviceProvider)
        {
            var eventBus = serviceProvider.GetRequiredService<IEventBus>();
            eventBus.Subscribe<TestEvent, TestEventHandler>();
        }
    }
}