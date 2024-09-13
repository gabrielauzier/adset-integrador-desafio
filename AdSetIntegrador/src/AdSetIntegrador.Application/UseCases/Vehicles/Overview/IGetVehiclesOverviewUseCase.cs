using AdSetIntegrador.Communication.Responses;

namespace AdSetIntegrador.Application.UseCases.Vehicles.Overview;

public interface IGetVehiclesOverviewUseCase
{
    public ResponseGetVehiclesOverviewDTO Execute();
}
