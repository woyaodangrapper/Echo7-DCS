using ECHO.SharedKernel.ApiService.Authentication;
using ECHO.SharedKernel.ApiService.Authorization;

namespace ECHO.SharedKernel.ApiService.Registrar;

public abstract partial class AbstractWebApiDependencyRegistrar : IDependencyRegistrar
{
    public string Name => "apiservice";
    protected IConfiguration Configuration { get; init; }
    protected IServiceCollection Services { get; init; }
    protected IServiceInfo ServiceInfo { get; init; }

    /// <summary>
    /// 服务注册与系统配置
    /// </summary>
    /// <param name="services"><see cref="IServiceInfo"/></param>
    protected AbstractWebApiDependencyRegistrar(IServiceCollection services)
    {
        Services = services;
        Configuration = services.GetConfiguration();
        ServiceInfo = services.GetServiceInfo();
    }

    /// <summary>
    /// 注册服务入口方法
    /// </summary>
    public abstract void AddDcs();

    /// <summary>
    /// 注册Webapi通用的服务
    /// </summary>
    protected virtual void AddWebApiDefault() =>
        AddWebApiDefault<BearerAuthenticationRemoteProcessor, PermissionRemoteHandler>();

    /// <summary>
    /// 注册Webapi通用的服务
    /// </summary>
    /// <typeparam name="TAuthenticationProcessor"><see cref="AbstractAuthenticationProcessor"/></typeparam>
    /// <typeparam name="TAuthorizationHandler"><see cref="AbstractPermissionHandler"/></typeparam>
    protected virtual void AddWebApiDefault<TAuthenticationProcessor, TAuthorizationHandler>()
        where TAuthenticationProcessor : AbstractAuthenticationProcessor
        where TAuthorizationHandler : AbstractPermissionHandler
    {
        Services
            .AddHttpContextAccessor()
            .AddMemoryCache();
        Configure();
        AddControllers();
        AddAuthentication<TAuthenticationProcessor>();
        AddAuthorization<TAuthorizationHandler>();
        AddCors();
        AddSwaggerGen();
        AddMiniProfiler();
        AddApplicationServices();
    }
}