using ECHO.Infrastructure.IRepositories;
using ECHO.Infrastructure.Repository.Mongo.Configuration;
using ECHO.Infrastructure.Repository.Mongo.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ECHO.Infrastructure.Repository.Mongo.Extensions
{
    /// <summary>
    /// Extensions for <see cref="IServiceCollection"/> to add easy MongoDB wiring.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the MongoDB context with the specified service collection.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configurator">The configurator.</param>
        /// <returns></returns>
        /// <remarks>
        /// This currently requires wiring up memory caching and logging.
        /// </remarks>
        public static MongoConfigurationBuilder AddDcsInfraMongo<TContext>(this IServiceCollection services, Action<MongoRepositoryOptions> configurator)
            where TContext : IMongoContext
        {
            if (services.HasRegistered(nameof(AddDcsInfraMongo)))
                return default;

            services.Configure(configurator);
            services.AddSingleton(typeof(IMongoContext), typeof(TContext));
            services.AddTransient(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddTransient(typeof(ISoftDeletableMongoRepository<>), typeof(SoftDeletableMongoRepository<>));
            return new MongoConfigurationBuilder(services);
        }

        /// <summary>
        /// Registers the MongoDB context with the specified service collection.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <returns></returns>
        /// <remarks>
        /// This currently requires wiring up memory caching and logging.
        /// </remarks>
        public static MongoConfigurationBuilder AddDcsInfraMongo<TContext>(this IServiceCollection services, string connectionString)
             where TContext : IMongoContext
        {
            return services.AddDcsInfraMongo<TContext>(c => c.ConnectionString = connectionString);
        }
    }
}