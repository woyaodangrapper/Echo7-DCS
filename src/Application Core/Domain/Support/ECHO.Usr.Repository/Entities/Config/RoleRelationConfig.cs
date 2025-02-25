﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ECHO.SharedKernel.Repository.EfEntities.Config;

namespace ECHO.Usr.Repository.Entities.Config;

public class RelationConfig : AbstractEntityTypeConfiguration<RoleRelation>
{
    public override void Configure(EntityTypeBuilder<RoleRelation> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.RoleId);
        builder.Property(x => x.MenuId);
    }
}