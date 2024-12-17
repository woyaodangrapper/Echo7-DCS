using ECHO.Infrastructure.Redis.Caching;
using ECHO.Infrastructure.Redis.Caching.Configurations;
using ECHO.Infrastructure.Redis.Caching.Core.Interceptor;
using ECHO.Infrastructure.Redis.Caching.Interceptor.Castle;
using ECHO.Infrastructure.Redis.Caching.Provider;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDcsInfraRedisCaching(this IServiceCollection services, IConfigurationSection redisSection, IConfigurationSection cachingSection)
    {
        if (services.HasRegistered(nameof(AddDcsInfraRedisCaching)))
            return services;

        return services
            .AddDcsInfraRedis(redisSection)
            .Configure<CacheOptions>(cachingSection)
            .AddSingleton<ICacheProvider, DefaultCachingProvider>()
            .AddSingleton<ICachingKeyGenerator, DefaultCachingKeyGenerator>()
            .AddScoped<CachingInterceptor>()
            .AddScoped<CachingAsyncInterceptor>();
    }
}