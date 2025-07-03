using BuildingBlock.Events;
using BuildingBlocks.EventBus.Abstractions;
using System.Threading.Tasks;

namespace NotificationService.EventHandlers
{
    public class TestEventHandler : IEventHandler<TestEvent>
    {
        public Task Handle(TestEvent @event)
        {
            Console.WriteLine($"Received message: {@event.message}");
            return Task.CompletedTask;
        }
    }
}