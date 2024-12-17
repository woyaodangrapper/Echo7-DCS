using ECHO.Infrastructure.EventBus;
using ECHO.Infrastructure.EventBus.Cap;
using ECHO.Infrastructure.EventBus.Cap.Filters;
using ECHO.Infrastructure.EventBus.Configurations;
using ECHO.Infrastructure.EventBus.RabbitMq;
using DotNetCore.CAP;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDcsInfraCap<TSubscriber>(this IServiceCollection services, Action<CapOptions> setupAction)
        where TSubscriber : class, ICapSubscribe
    {
        if (services.HasRegistered(nameof(AddDcsInfraCap)))
            return services;
        services
            .AddSingleton<IEventPublisher, CapPublisher>()
            .AddScoped<TSubscriber>()
            .AddCap(setupAction)
            .AddSubscribeFilter<DefaultCapFilter>()
            ;
        return services;
    }

    public static IServiceCollection AddDcsInfraRabbitMq(this IServiceCollection services, IConfigurationSection rabitmqSection)
    {
        if (services.HasRegistered(nameof(AddDcsInfraRabbitMq)))
            return services;

        return services
             .Configure<RabbitMqOptions>(rabitmqSection)
             .AddSingleton<IRabbitMqConnection>(provider =>
             {
                 var options = provider.GetRequiredService<IOptions<RabbitMqOptions>>();
                 var logger = provider.GetRequiredService<ILogger<RabbitMqConnection>>();
                 var serviceInfo = services.GetServiceInfo();
                 var clientProvidedName = serviceInfo?.Id ?? "unkonow";
                 return RabbitMqConnection.GetInstance(options, clientProvidedName, logger);
             })
             .AddSingleton<RabbitMqProducer>()
             ;
    }
}