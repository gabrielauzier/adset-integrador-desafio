using AdSetIntegrador.Communication.Requests;

namespace AdSetIntegrador.Application.UseCases.Vehicles.Delete;

public interface IDeleteVehicleUseCase
{
    public void Execute(RequestDeleteVehicleDTO request);
}
