using ECHO.Dcs.Contracts.Services;
using ECHO.Dcs.Entities;
using ECHO.SharedKernel.Const;
using ECHO.SharedKernel.Rpc.Http.Services;

namespace ECHO.Dcs.Application.Registrar;

public sealed class DcsApplicationDependencyRegistrar : AbstractApplicationDependencyRegistrar
{
    public override Assembly ApplicationLayerAssembly => Assembly.GetExecutingAssembly();

    public override Assembly ContractsLayerAssembly => typeof(ISayHelloAppService).Assembly;

    public override Assembly RepositoryOrDomainLayerAssembly => typeof(EntityInfo).Assembly;

    public DcsApplicationDependencyRegistrar(IServiceCollection services) : base(services)
    {
    }

    public override void AddDcs()
    {
        AddApplicaitonDefault();
        //rpc-event

        //rpc-restclient
        var restPolicies = this.GenerateDefaultRefitPolicies();
        AddRestClient<IAuthRestClient>(ServiceAddressConsts.UsrService, restPolicies);
        AddRestClient<IUsrRestClient>(ServiceAddressConsts.UsrService, restPolicies);

        //rpc-grpcclient
        var gprcPolicies = this.GenerateDefaultGrpcPolicies();

        //rpc-even
        AddRabbitMqClient();
    }
}