namespace ECHO.SharedKernel.ApiService.Authentication.Bearer;

public class BearerPostConfigureOptions : IPostConfigureOptions<BearerSchemeOptions>
{
    public void PostConfigure(string name, BearerSchemeOptions options)
    {
        // Method intentionally left empty.
    }
}