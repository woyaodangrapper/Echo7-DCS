using ECHO.Infrastructure.Entities;
using ECHO.Infrastructure.Repository.Mongo.Configuration;

namespace ECHO.Infrastructure.Repository.Mongo.Interfaces
{
    /// <summary>
    /// Mongo entity configuration.
    /// </summary>
    public interface IMongoEntityConfiguration<TEntity>
        where TEntity : MongoEntity
    {
        void Configure(MongoEntityBuilder<TEntity> context);
    }
}