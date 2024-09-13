using AdSetIntegrador.Communication.Requests;
using AdSetIntegrador.Domain.Entities;

namespace AdSetIntegrador.Application.UseCases.Vehicles.List;

public interface IListVehiclesUseCase
{
    List<Vehicle> Execute(RequestListVehiclesDTO request);
}
