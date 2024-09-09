using AdSetIntegrador.Communication.Requests;
using AdSetIntegrador.Communication.Responses;
using AdSetIntegrador.Domain.Entities;
using AdSetIntegrador.Domain.Repositories;

namespace AdSetIntegrador.Application.UseCases.Vehicles.Register;

public class RegisterVehicleUseCase : IRegisterVehicleUseCase
{
    private readonly IVehiclesRepository _vehiclesRepository;

    public RegisterVehicleUseCase(IVehiclesRepository vehiclesRepository)
    {
        _vehiclesRepository = vehiclesRepository;
    }


    public ResponseRegisterVehicleJson Execute(RequestRegisterVehicleJson request)
    {
        var vehicle = new Vehicle
        {
            Brand = request.Brand,
            Color = request.Color,
            Mileage = request.Mileage,
            Model = request.Model,
            Plate = request.Plate,
            Price = request.Price,
            Year = request.Year,
        };

        _vehiclesRepository.Create(vehicle);

        return new ResponseRegisterVehicleJson { Id = vehicle.Id };
    }
}
