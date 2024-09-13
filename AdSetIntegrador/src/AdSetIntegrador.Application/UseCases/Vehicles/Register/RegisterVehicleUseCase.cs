using AdSetIntegrador.Communication.Requests;
using AdSetIntegrador.Communication.Responses;
using AdSetIntegrador.Domain.Entities;
using AdSetIntegrador.Domain.Repositories;

namespace AdSetIntegrador.Application.UseCases.Vehicles.Register;

public class RegisterVehicleUseCase : IRegisterVehicleUseCase
{
    private readonly IVehiclesRepository _vehiclesRepository;
    private readonly IImagesRepository _imagesRepository;

    public RegisterVehicleUseCase(IVehiclesRepository vehiclesRepository, IImagesRepository imagesRepository)
    {
        _vehiclesRepository = vehiclesRepository;
        _imagesRepository = imagesRepository;
    }

    public ResponseRegisterVehicleJson Execute(RequestRegisterVehicleJson request)
    {
        var vehicle = new Vehicle
        {
            Brand = request.Brand,
            Color = request.Color,
            Mileage = request.Mileage,
            Model = request.Model,
            Plate = request.Plate,
            Price = request.Price,
            Year = request.Year,
            Optional = request.Optional
        };
        _vehiclesRepository.Create(vehicle);

        foreach(var Image in request.Images)
        {
            _imagesRepository.Upload(new Image
            {
                Name = Image.Name,
                Description = Image.Description,
                ContentType = Image.ContentType,
                Raw = Image.Raw,
                VehicleId = vehicle.Id
            });
        }

        _vehiclesRepository.Save();

        return new ResponseRegisterVehicleJson { Id = vehicle.Id };
    }

    private void Validate(RequestRegisterVehicleJson request)
    {
        var validator = new RegisterVehicleValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
