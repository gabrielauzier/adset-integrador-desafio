using AdSetIntegrador.Communication.Requests;
using AdSetIntegrador.Exception;
using FluentValidation;

namespace AdSetIntegrador.Application.UseCases.Vehicles.Delete;

public class DeleteVehicleValidator : AbstractValidator<RequestDeleteVehicleDTO>
{
    public DeleteVehicleValidator() 
    {
        RuleFor(vehicle => vehicle.Id).NotEmpty().WithMessage(ResourceErrorMessages.VEHICLE_ID_REQUIRED);
    }
}
