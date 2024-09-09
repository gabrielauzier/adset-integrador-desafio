using AdSetIntegrador.Application.UseCases.Vehicles.Register;
using AdSetIntegrador.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AdSetIntegrador.Api.Controllers.Vehicle;

[Route("api/vehicle")]
[ApiController]
public class RegisterVehicleController : ControllerBase
{
    [HttpPost]
    public IActionResult Handle(
        [FromServices] IRegisterVehicleUseCase useCase,
        [FromBody] RequestRegisterVehicleJson request
    ) {
        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }
}
