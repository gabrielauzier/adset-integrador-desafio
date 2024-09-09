using AdSetIntegrador.Communication.Requests;
using AdSetIntegrador.Communication.Responses;

namespace AdSetIntegrador.Application.UseCases.Vehicle.Register;

public class RegisterVehicleUseCase : IRegisterVehicleUseCase
{
    public ResponseRegisterVehicleJson Execute(RequestRegisterVehicleJson request)
    {
        return new ResponseRegisterVehicleJson();
    }
}
