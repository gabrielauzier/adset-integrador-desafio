using Microsoft.AspNetCore.Mvc;

namespace AdSetIntegrador.Api.Controllers.HealthChecker;

[Route("api/health-checker")]
[ApiController]
public class HealthCheckerController : ControllerBase
{
    [HttpGet]
    public IActionResult Handle()
    {
        return Ok("Service running.");
    }
}
