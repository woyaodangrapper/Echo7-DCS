﻿namespace ECHO.SharedKernel.ApiService.Authentication.Basic;

public class BasicEvents
{
    public Func<BasicTokenValidatedContext, Task> OnTokenValidated { get; set; }

    //public virtual Task TokenValidated(BasicTokenValidatedContext context) => OnTokenValidated(context);
}
