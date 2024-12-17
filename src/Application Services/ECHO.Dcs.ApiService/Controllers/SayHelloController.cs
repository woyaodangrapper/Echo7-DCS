using ECHO.Dcs.Contracts.Dtos;
using ECHO.Dcs.Contracts.Services;

namespace ECHO.Dcs.ApiService.Controllers;

[Route("say")]
[ApiController]
public class SayHelloController : DcsControllerBase
{
    private readonly ISayHelloAppService _sayHelloAppService;

    public SayHelloController(ISayHelloAppService sayHelloAppService) => _sayHelloAppService = sayHelloAppService;

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<HelloDto>>> GetListAsync() =>
        CreatedResult(await _sayHelloAppService.GetListAsync());
}