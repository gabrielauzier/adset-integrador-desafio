using AdSetIntegrador.Domain.Entities;
using AdSetIntegrador.Domain.Repositories;

namespace AdSetIntegrador.Application.UseCases.Vehicles.List;

public class ListVehiclesUseCase : IListVehiclesUseCase
{
    private readonly IVehiclesRepository _vehiclesRepository;

    public ListVehiclesUseCase(IVehiclesRepository vehiclesRepository)
    {
        _vehiclesRepository = vehiclesRepository;
    }

    public List<Vehicle> Execute()
    {
        var vehicles = _vehiclesRepository.List();

        return vehicles;
    }
}
