using AdSetIntegrador.Application.UseCases.Vehicles.Delete;
using AdSetIntegrador.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AdSetIntegrador.Api.Controllers.Vehicle;

[Route("api/vehicle")]
[ApiController]
public class DeleteVehicleController : ControllerBase
{
    [HttpDelete]
    public IActionResult Handle(
        [FromServices] IDeleteVehicleUseCase useCase,
        [FromBody] RequestDeleteVehicleDTO request
    )
    {
        useCase.Execute(request);

        return NoContent();
    }
}
