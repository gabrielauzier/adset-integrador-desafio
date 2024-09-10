using AdSetIntegrador.Communication.Requests;
using AdSetIntegrador.Communication.Responses;

namespace AdSetIntegrador.Application.UseCases.Vehicles.Update;

public interface IUpdateVehicleUseCase
{
    public ResponseUpdateVehicleJson Execute(RequestUpdateVehicleJson request);
}
