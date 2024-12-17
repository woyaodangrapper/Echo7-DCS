using ECHO.Infrastructure.IRepositories;

namespace ECHO.Infrastructure.Entities;

public interface IEntityInfo
{
    Operater GetOperater();

    void OnModelCreating(dynamic modelBuilder);
}