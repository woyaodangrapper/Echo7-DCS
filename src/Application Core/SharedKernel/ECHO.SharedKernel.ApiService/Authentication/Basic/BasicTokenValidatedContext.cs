namespace ECHO.SharedKernel.ApiService.Authentication.Basic;

public class BasicTokenValidatedContext : ResultContext<BasicSchemeOptions>
{
    public BasicTokenValidatedContext(HttpContext context, AuthenticationScheme scheme, BasicSchemeOptions options)
        : base(context, scheme, options)
    {
    }
}