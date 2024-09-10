using AdSetIntegrador.Domain.Entities;

namespace AdSetIntegrador.Application.UseCases.Vehicles.List;

public interface IListVehiclesUseCase
{
    List<Vehicle> Execute();
}
