namespace ECHO.Infrastructure.Repository.EfCore.SqlServer;

public class SqlServerDbContext : DcsDbContext
{
    public SqlServerDbContext(
        DbContextOptions options,
        IEntityInfo entityInfo)
        : base(options, entityInfo)
    {
    }
}