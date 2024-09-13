using AdSetIntegrador.Application.UseCases.Vehicles.GetVehicleById;
using AdSetIntegrador.Domain.Entities;
using AdSetIntegrador.Domain.Repositories;

namespace AdSetIntegrador.Application.UseCases.Vehicles.GetById;

public class GetVehicleByIdUseCase : IGetVehicleByIdUseCase
{
    private readonly IVehiclesRepository _vehiclesRepository;

    public GetVehicleByIdUseCase(IVehiclesRepository vehiclesRepository)
    {
        _vehiclesRepository = vehiclesRepository;
    }

    public Vehicle Execute(int vehicleId)
    {
        System.Console.WriteLine("Vehicle ID = " + vehicleId);
        var vehicle = _vehiclesRepository.GetById(vehicleId);

        return vehicle;
    }
}
