using ECHO.SharedKernel.ApiService.Registrar;

namespace ECHO.Dcs.ApiService.Registrar;

public sealed class DcsWebApiDependencyRegistrar : AbstractWebApiDependencyRegistrar
{
    public DcsWebApiDependencyRegistrar(IServiceCollection services)
        : base(services)
    {
    }

    public DcsWebApiDependencyRegistrar(IApplicationBuilder app)
        : base(app)
    {
    }

    public override void AddDcs()
    {
        AddWebApiDefault();
        AddHealthChecks(false, false, true, false);
        //Services.AddGrpc();
    }

    public override void UseDcs()
    {
        UseWebApiDefault(endpointRoute: endpoint =>
        { });
    }
}