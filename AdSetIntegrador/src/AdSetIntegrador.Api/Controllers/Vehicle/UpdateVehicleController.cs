using AdSetIntegrador.Application.UseCases.Vehicles.Update;
using AdSetIntegrador.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AdSetIntegrador.Api.Controllers.Vehicle;

[Route("api/vehicle")]
[ApiController]
public class UpdateVehicleController : ControllerBase
{
    [HttpPut]
    public IActionResult Handle(
        [FromServices] IUpdateVehicleUseCase useCase,
        [FromBody] RequestUpdateVehicleJson request
    )
    {
        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }
}
