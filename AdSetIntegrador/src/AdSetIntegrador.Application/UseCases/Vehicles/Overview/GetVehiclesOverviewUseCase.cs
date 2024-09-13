using AdSetIntegrador.Communication.Responses;
using AdSetIntegrador.Domain.Repositories;

namespace AdSetIntegrador.Application.UseCases.Vehicles.Overview;

internal class GetVehiclesOverviewUseCase : IGetVehiclesOverviewUseCase
{
    private readonly IVehiclesRepository _vehiclesRepository;

    public GetVehiclesOverviewUseCase(IVehiclesRepository vehiclesRepository)
    {
        _vehiclesRepository = vehiclesRepository;
    }

    public ResponseGetVehiclesOverviewDTO Execute()
    {
        var total = _vehiclesRepository.CountTotal();
        var totalWithImages = _vehiclesRepository.CountWithImages();
        var totalWithoutImages = _vehiclesRepository.CountWithoutImages();
        var colors = _vehiclesRepository.GetAllColors();

        return new ResponseGetVehiclesOverviewDTO
        {
            Colors = colors,
            Total = total,
            TotalWithImages = totalWithImages,
            TotalWithoutImages = totalWithoutImages
        };

    }
}
