using ECHO.Infrastructure.IdGenerater.Yitter;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDcsInfraYitterIdGenerater(this IServiceCollection services, IConfigurationSection redisSection)
    {
        if (services.HasRegistered(nameof(AddDcsInfraYitterIdGenerater)))
            return services;

        return services
            .AddDcsInfraRedis(redisSection)
            .AddSingleton<WorkerNode>()
            .AddHostedService<WorkerNodeHostedService>();
    }
}