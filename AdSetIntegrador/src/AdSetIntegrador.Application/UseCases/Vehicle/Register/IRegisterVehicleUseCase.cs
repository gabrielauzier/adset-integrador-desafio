using AdSetIntegrador.Communication.Requests;
using AdSetIntegrador.Communication.Responses;

namespace AdSetIntegrador.Application.UseCases.Vehicle.Register;

public interface IRegisterVehicleUseCase
{
    public ResponseRegisterVehicleJson Execute(RequestRegisterVehicleJson request);
}
