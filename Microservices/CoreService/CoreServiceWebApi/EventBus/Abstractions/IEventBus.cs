using System;

namespace BuildingBlocks.EventBus.Abstractions;

public interface IEventBus
{
    void Subscribe<T, TH>()
        where T : IEvent
        where TH : IEventHandler<T>;
}