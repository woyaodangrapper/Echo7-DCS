using ECHO.SharedKernel.ApiService.Registrar;
using ECHO.User.ApiService.Authentication;
using ECHO.User.ApiService.Authorization;
using ECHO.User.ApiService.Grpc;

namespace ECHO.Usr.ApiService.Registrar;

public sealed class UsrWebApiDependencyRegistrar : AbstractWebApiDependencyRegistrar
{
    public UsrWebApiDependencyRegistrar(IServiceCollection services)
        : base(services)
    {
    }

    public UsrWebApiDependencyRegistrar(IApplicationBuilder app)
        : base(app)
    {
    }

    public override void AddDcs()
    {
        AddWebApiDefault<BearerAuthenticationLocalProcessor, PermissionLocalHandler>();
        AddHealthChecks(false, false, false, false);
        Services.AddGrpc();
    }

    public override void UseDcs()
    {
        UseWebApiDefault(endpointRoute: endpoint =>
        {
            endpoint.MapGrpcService<AuthGrpcServer>();
            endpoint.MapGrpcService<AuthGrpcServer>();
        });
    }
}