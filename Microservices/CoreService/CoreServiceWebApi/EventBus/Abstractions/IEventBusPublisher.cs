namespace BuildingBlocks.EventBus.Abstractions;

public interface IEventBusPublisher
{
    void Publish<T>(T @event) where T : IEvent;
}