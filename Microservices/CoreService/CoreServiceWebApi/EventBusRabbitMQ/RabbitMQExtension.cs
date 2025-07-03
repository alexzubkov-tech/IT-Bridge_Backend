using BuildingBlocks.EventBus.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.EventBusRabbitMQ;

public static class RabbitMQExtension
{
    public static IServiceCollection RegisterRabbit(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
        {
            var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
            return new RabbitMQBus(scopeFactory, configuration);
        });

        return services;
    }
}