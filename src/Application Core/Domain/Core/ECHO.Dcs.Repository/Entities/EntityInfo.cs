using Microsoft.EntityFrameworkCore;
using ECHO.SharedKernel;
using ECHO.SharedKernel.Repository.EfEntities;
using System.Reflection;

namespace ECHO.Dcs.Entities;

public class EntityInfo : AbstracSharedEntityInfo
{
    public EntityInfo(UserContext userContext) : base(userContext)
    {
    }

    protected override Assembly GetCurrentAssembly() => GetType().Assembly;

    protected override void SetTableName(dynamic modelBuilder)
    {
        if (modelBuilder is not ModelBuilder builder)
            throw new ArgumentNullException(nameof(modelBuilder));
        builder.Entity<SysHello>().ToTable("sys_hello");
    }
}