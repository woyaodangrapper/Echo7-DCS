namespace ECHO.Dcs.Contracts.Services;

public interface ISayHelloAppService : IAppService
{
    Task<AppSrvResult<List<HelloDto>>> GetListAsync();
}