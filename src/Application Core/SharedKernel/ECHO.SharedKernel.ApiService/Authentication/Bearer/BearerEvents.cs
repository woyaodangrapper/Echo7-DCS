namespace ECHO.SharedKernel.ApiService.Authentication.Bearer;

public class BearerEvents
{
    public Func<BearerTokenValidatedContext, Task> OnTokenValidated { get; set; }
}
