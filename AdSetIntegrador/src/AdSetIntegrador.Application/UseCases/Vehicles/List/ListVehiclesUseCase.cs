using AdSetIntegrador.Communication.Requests;
using AdSetIntegrador.Domain.Entities;
using AdSetIntegrador.Domain.Enums;
using AdSetIntegrador.Domain.Repositories;

namespace AdSetIntegrador.Application.UseCases.Vehicles.List;

public class ListVehiclesUseCase : IListVehiclesUseCase
{
    private readonly IVehiclesRepository _vehiclesRepository;

    public ListVehiclesUseCase(IVehiclesRepository vehiclesRepository)
    {
        _vehiclesRepository = vehiclesRepository;
    }

    public List<Vehicle> Execute(RequestListVehiclesDTO request)
    {
        var vehicles = _vehiclesRepository.List(new Domain.Options.ListVehiclesOptions
        {
            PriceRange = (PriceRange)request.PriceRange,
            Brand = request.Brand,
            Color = request.Color,
            MaxYear = request.MaxYear,
            MinYear = request.MinYear,
            Model = request.Model,  
            Optional = request.Optional,
            Photos = (PhotosOption)request.Photos,
            Plate = request.Plate
        });

        return vehicles ?? [];
    }
}
