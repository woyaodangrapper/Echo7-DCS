using ECHO.Dcs.Contracts.Dtos;
using ECHO.Dcs.Contracts.Services;

namespace ECHO.Dcs.Application.Services;

public class SayHelloAppService : AbstractAppService, ISayHelloAppService
{
    public async Task<AppSrvResult<List<HelloDto>>> GetListAsync()
    {
        return await Task.FromResult(new List<HelloDto>() { new () {
         Content ="Hello World",
        } });
    }
}