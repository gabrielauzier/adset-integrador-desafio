using AdSetIntegrador.Communication.Requests;
using AdSetIntegrador.Domain.Repositories;

namespace AdSetIntegrador.Application.UseCases.Vehicles.Delete;

public class DeleteVehicleUseCase : IDeleteVehicleUseCase
{
    private readonly IVehiclesRepository _vehiclesRepository;

    public DeleteVehicleUseCase(IVehiclesRepository vehiclesRepository)
    {
        _vehiclesRepository = vehiclesRepository;
    }

    public void Execute(int vehicleId)
    {
        var vehicle = _vehiclesRepository.GetById(vehicleId);

        if (vehicle == null)
        {
            throw new ResourceNotFoundException("Vehicle not found.");
        }

        _vehiclesRepository.Delete(vehicle);
    }

    private void Validate(RequestDeleteVehicleDTO request)
    {
        var validator = new DeleteVehicleValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
