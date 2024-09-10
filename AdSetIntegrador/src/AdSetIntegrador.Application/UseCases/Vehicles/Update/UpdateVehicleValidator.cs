using AdSetIntegrador.Communication.Requests;
using AdSetIntegrador.Exception;
using FluentValidation;

namespace AdSetIntegrador.Application.UseCases.Vehicles.Update;

public class UpdateVehicleValidator : AbstractValidator<RequestUpdateVehicleJson>
{
    public UpdateVehicleValidator()
    {
        RuleFor(vehicle => vehicle.Id).NotEmpty().WithMessage(ResourceErrorMessages.VEHICLE_ID_REQUIRED);
        RuleFor(vehicle => vehicle.Brand).NotEmpty().WithMessage(ResourceErrorMessages.BRAND_REQUIRED);
        RuleFor(vehicle => vehicle.Model).NotEmpty().WithMessage(ResourceErrorMessages.MODEL_REQUIRED);
        RuleFor(vehicle => vehicle.Year).NotEmpty().WithMessage(ResourceErrorMessages.YEAR_REQUIRED);
        RuleFor(vehicle => vehicle.Year).InclusiveBetween(2000, 2024).WithMessage(ResourceErrorMessages.YEAR_RANGE_INVALID);
        RuleFor(vehicle => vehicle.Plate).NotEmpty().WithMessage(ResourceErrorMessages.PLATE_REQUIRED);
        RuleFor(vehicle => vehicle.Color).NotEmpty().WithMessage(ResourceErrorMessages.COLOR_REQUIRED);
        RuleFor(vehicle => vehicle.Price).GreaterThan(0).WithMessage(ResourceErrorMessages.PRICE_INVALID);
    }
}
