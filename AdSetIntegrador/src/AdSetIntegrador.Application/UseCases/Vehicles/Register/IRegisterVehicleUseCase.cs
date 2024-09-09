using AdSetIntegrador.Communication.Requests;
using AdSetIntegrador.Communication.Responses;

namespace AdSetIntegrador.Application.UseCases.Vehicles.Register;

public interface IRegisterVehicleUseCase
{
    public ResponseRegisterVehicleJson Execute(RequestRegisterVehicleJson request);
}
