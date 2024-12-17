namespace ECHO.SharedKernel.ApiService.Authorization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
public class DcsAuthorizeAttribute : AuthorizeAttribute
{
    public const string JwtWithBasicSchemes = $"{JwtBearerDefaults.AuthenticationScheme},{Authentication.Basic.BasicDefaults.AuthenticationScheme}";

    public string[] Codes { get; set; }

    public DcsAuthorizeAttribute(string code, string schemes = JwtBearerDefaults.AuthenticationScheme)
        : this(new string[] { code }, schemes)
    {
    }

    public DcsAuthorizeAttribute(string[] codes, string schemes = JwtBearerDefaults.AuthenticationScheme)
    {
        Codes = codes;
        Policy = AuthorizePolicy.Default;
        if (schemes.IsNullOrWhiteSpace())
            throw new ArgumentNullException(nameof(schemes));
        else
            AuthenticationSchemes = schemes;
    }
}