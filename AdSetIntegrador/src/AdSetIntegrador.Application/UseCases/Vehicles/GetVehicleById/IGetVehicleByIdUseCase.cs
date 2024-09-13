using AdSetIntegrador.Domain.Entities;

namespace AdSetIntegrador.Application.UseCases.Vehicles.GetVehicleById;

public interface IGetVehicleByIdUseCase
{
    public Vehicle Execute(int vehicleId);
}
