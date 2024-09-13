using AdSetIntegrador.Application.UseCases.Vehicles.List;
using AdSetIntegrador.Application.UseCases.Vehicles.Register;
using AdSetIntegrador.Application.UseCases.Vehicles.GetVehicleById;
using AdSetIntegrador.Application.UseCases.Vehicles.Delete;
using AdSetIntegrador.Application.UseCases.Vehicles.Update;
using AdSetIntegrador.Presentation.Models;
using AdSetIntegrador.Presentation.Mappers;
using Microsoft.AspNetCore.Mvc;
using AdSetIntegrador.Communication.Requests;

namespace AdSetIntegrador.Presentation.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index(
            ListViewModel listViewModel,
            [FromServices] IListVehiclesUseCase useCase
        )
        {
            try
            {
                System.Console.WriteLine("AQUI 22222222");

                var request = new RequestListVehiclesDTO();

                if (listViewModel.Filter != null)
                {
                    request = FilterMapper.ToRequest(listViewModel.Filter);
                }

                System.Console.WriteLine("Oia => " + request.Brand);

                var response = useCase.Execute(request);

                return View("Index", new ListViewModel
                {
                    Filter = FilterMapper.ToFilter(request),
                    Vehicles = VehicleMapper.VehiclesToListView(response)
                });
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Caiu aqui no erro, pae");
                System.Console.WriteLine(ex.Message);
                System.Console.WriteLine(ex.StackTrace);
                return View("Index", listViewModel);
            };
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
