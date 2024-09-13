using AdSetIntegrador.Application.UseCases.Vehicles.List;
using AdSetIntegrador.Application.UseCases.Vehicles.Register;
using AdSetIntegrador.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using AdSetIntegrador.Presentation.Mappers;
using AdSetIntegrador.Application.UseCases.Vehicles.GetVehicleById;
using AdSetIntegrador.Domain.Repositories;
using AdSetIntegrador.Application.UseCases.Vehicles.Delete;
using AdSetIntegrador.Application.UseCases.Vehicles.Update;

namespace AdSetIntegrador.Presentation.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index(
            [FromServices] IListVehiclesUseCase useCase
        ) {
            var response = useCase.Execute();
            var vehicleModel = VehicleMapper.ToViewList(response);

            return View(vehicleModel);
        }

        public IActionResult Register()
        {
            ViewBag.Action = "Register";
            return View("Register", new VehicleModel());
        }

        public IActionResult Update(
            int vehicleId,
            [FromServices] IGetVehicleByIdUseCase useCase
        )
        {
            var vehicle = useCase.Execute(vehicleId);

            if (vehicle == null)
            {
                return View("Index");
            }

            return View("Update", VehicleMapper.ToView(vehicle));
        }

        public IActionResult Delete(
            int vehicleId,
            [FromServices] IDeleteVehicleUseCase useCase
        )
        {
            useCase.Execute(vehicleId);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Register(
             VehicleModel vehicle,
             [FromServices] IRegisterVehicleUseCase useCase
        )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = useCase.Execute(VehicleMapper.ToRegister(vehicle));
                    return RedirectToAction("Index");
                }
                return View(vehicle);
            }
            catch
            {
                return View(vehicle);
            }
        }

        [HttpPost]
        public IActionResult Update(
            VehicleModel vehicle,
            [FromServices] IUpdateVehicleUseCase useCase
        )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = useCase.Execute(VehicleMapper.ToUpdate(vehicle));
                    return RedirectToAction("Index");
                }
                return View(vehicle);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return View(vehicle);
            }
        }
    }
}
