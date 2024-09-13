using AdSetIntegrador.Communication.Requests;
using AdSetIntegrador.Communication.Responses;
using AdSetIntegrador.Domain.Repositories;

namespace AdSetIntegrador.Application.UseCases.Vehicles.Update;

public class UpdateVehicleUseCase : IUpdateVehicleUseCase
{
    private readonly IVehiclesRepository _vehiclesRepository;

    public UpdateVehicleUseCase(IVehiclesRepository vehiclesRepository)
    {
        _vehiclesRepository = vehiclesRepository;
    }

    public ResponseUpdateVehicleJson Execute(RequestUpdateVehicleJson request)
    {
        var vehicle = _vehiclesRepository.GetById(request.Id);

        if (vehicle == null)
        {
            throw new ResourceNotFoundException("Vehicle not found.");
        }

        vehicle.Brand = request.Brand;
        vehicle.Model = request.Model;
        vehicle.Year = request.Year;
        vehicle.Plate = request.Plate;
        vehicle.Mileage = request.Mileage;
        vehicle.Color = request.Color;
        vehicle.Price = request.Price;

        _vehiclesRepository.Save();

        return new ResponseUpdateVehicleJson { Id = vehicle.Id };
    }

    private void Validate(RequestUpdateVehicleJson request)
    {
        var validator = new UpdateVehicleValidator();
        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
