using AdSetIntegrador.Application.UseCases.Vehicles.List;
using AdSetIntegrador.Application.UseCases.Vehicles.Register;
using AdSetIntegrador.Communication.Requests;
using AdSetIntegrador.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

        public IActionResult Register()
        {
            ViewBag.Action = "Register";
            return View("Register", new VehicleModel());
        }

        [HttpPost]
        public IActionResult Register(
            VehicleModel vehicle,
            [FromServices] IRegisterVehicleUseCase useCase
        ) {
            try
            {
                if (ModelState.IsValid)
                {
                    useCase.Execute(new RequestRegisterVehicleJson
                    {
                        Brand = vehicle.Brand,
                        Color = vehicle.Color,
                        Mileage = vehicle.Mileage,
                        Model = vehicle.Model,
                        Plate = vehicle.Plate,
                        Price = vehicle.Price,
                        Year = vehicle.Year
                    });
                }
                return RedirectToAction("Index");
            }
            catch {
                return RedirectToAction("Index");
            }
        }
    }
}
