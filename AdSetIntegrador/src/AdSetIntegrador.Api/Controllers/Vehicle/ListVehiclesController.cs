using AdSetIntegrador.Application.UseCases.Vehicles.List;
using Microsoft.AspNetCore.Mvc;

namespace AdSetIntegrador.Api.Controllers.Vehicle;

[Route("api/vehicle")]
[ApiController]
public class ListVehiclesController : ControllerBase
{
    [HttpGet]
    public IActionResult Handle(
        [FromServices] IListVehiclesUseCase useCase
    )
    {
        var response = useCase.Execute();

        return Created(string.Empty, response);
    }
}
