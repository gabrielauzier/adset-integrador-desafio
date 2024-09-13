using AdSetIntegrador.Application.UseCases.Vehicles.List;
using AdSetIntegrador.Application.UseCases.Vehicles.Register;
using AdSetIntegrador.Application.UseCases.Vehicles.GetVehicleById;
using AdSetIntegrador.Application.UseCases.Vehicles.Delete;
using AdSetIntegrador.Application.UseCases.Vehicles.Update;
using AdSetIntegrador.Presentation.Models;
using AdSetIntegrador.Presentation.Mappers;
using Microsoft.AspNetCore.Mvc;
using AdSetIntegrador.Communication.Requests;
using AdSetIntegrador.Domain.Entities;
using AdSetIntegrador.Application.UseCases.Vehicles.Overview;

namespace AdSetIntegrador.Presentation.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index(
            ListViewModel listViewModel,
            [FromServices] IListVehiclesUseCase listVehicles,
            [FromServices] IGetVehiclesOverviewUseCase getVehiclesOverview
        )
        {
            try
            {
                var request = new RequestListVehiclesDTO();

                if (listViewModel.Filter != null)
                {
                    request = FilterMapper.ToRequest(listViewModel.Filter);
                }

                var vehicles = listVehicles.Execute(request);
                var overview = getVehiclesOverview.Execute();

                return View("Index", new ListViewModel
                {
                    Filter = FilterMapper.ToFilter(request),
                    Overview = OverviewMapper.ToView(overview),
                    Vehicles = VehicleMapper.VehiclesToListView(vehicles)
                });
            }
            catch
            {
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
        public async Task<IActionResult> Register(
             VehicleModel vehicle,
             ICollection<IFormFile> imageFiles,
             [FromServices] IListVehiclesUseCase listVehicles,
             [FromServices] IRegisterVehicleUseCase useCase,
             [FromServices] IGetVehiclesOverviewUseCase getVehiclesOverview
        )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var imagesToUpload = new List<Image>();

                    foreach (var imageFile in imageFiles)
                    {
                        if (imageFile.Length > 0)
                        {
                            using var memoryStream = new MemoryStream();
                            await imageFile.CopyToAsync(memoryStream);
                            var imageData = memoryStream.ToArray();

                            var image = new Image
                            {
                                Name = imageFile.Name,
                                ContentType = imageFile.ContentType,
                                Raw = imageData,
                                Description = "Foto de veículo"
                            };

                            imagesToUpload.Add(image);
                        }
                    }
                
                    var response = useCase.Execute(VehicleMapper.ToRegister(vehicle, imagesToUpload));
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
        public async Task<IActionResult> Update(
            VehicleModel vehicle,
             ICollection<IFormFile> imageFiles,
            [FromServices] IUpdateVehicleUseCase useCase
        )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var imagesToUpload = new List<Image>();

                    foreach (var imageFile in imageFiles)
                    {
                        if (imageFile.Length > 0)
                        {
                            using var memoryStream = new MemoryStream();
                            await imageFile.CopyToAsync(memoryStream);
                            var imageData = memoryStream.ToArray();

                            var image = new Image
                            {
                                Name = imageFile.Name,
                                ContentType = imageFile.ContentType,
                                Raw = imageData,
                                Description = "Foto de veículo"
                            };

                            imagesToUpload.Add(image);
                        }
                    }

                    var response = useCase.Execute(VehicleMapper.ToUpdate(vehicle, imagesToUpload));
                    return RedirectToAction("Index");
                }
                return View(vehicle);
            }
            catch
            {
                return View(vehicle);
            }
        }
    }
}
