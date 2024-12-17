﻿namespace ECHO.Usr.Contracts.DtoValidators;

public class RoleSetPermissonsDtoValidator : AbstractValidator<RoleSetPermissonsDto>
{
    public RoleSetPermissonsDtoValidator()
    {
        RuleFor(x => x.RoleId).GreaterThan(0);
        RuleFor(x => x.Permissions).NotNull();
    }
}