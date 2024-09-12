using AdSetIntegrador.Application.UseCases.Vehicles.List;
using AdSetIntegrador.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdSetIntegrador.Presentation.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index(
            [FromServices] IListVehiclesUseCase useCase
        ) {
            var response = useCase.Execute();

            var vehicleModel = response.Select(vehicle => new VehicleModel            
            {
                Brand = vehicle.Brand,
                Color = vehicle.Color,
                Id = vehicle.Id,
                Mileage = vehicle.Mileage,
                Model = vehicle.Model,
                Plate = vehicle.Plate,
                Price = vehicle.Price,
                Year = vehicle.Year
            });

            return View(vehicleModel);
        }
    }
}
