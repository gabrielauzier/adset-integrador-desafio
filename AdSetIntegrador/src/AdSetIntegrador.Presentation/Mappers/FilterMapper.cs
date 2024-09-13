using AdSetIntegrador.Domain.Enums;
using AdSetIntegrador.Communication.Requests;
using AdSetIntegrador.Presentation.Models;

namespace AdSetIntegrador.Presentation.Mappers;

public static class FilterMapper
{
    public static RequestListVehiclesDTO ToRequest(FilterModel filter)
    {
        System.Console.WriteLine("amig, estou aqui...");
        System.Console.WriteLine("plate " + filter.Plate);
        System.Console.WriteLine("brand " + filter.Brand);
        System.Console.WriteLine("model " + filter.Model);

        return new RequestListVehiclesDTO
        {
            Plate = filter.Plate ?? "",
            Brand = filter.Brand ?? "",
            Model = filter.Model ?? "",
            MinYear = filter.MinYear ?? 2000,
            MaxYear = filter.MaxYear ?? 2024,
            PriceRange = (PriceRange)(filter.PriceRange ?? 0),
            Color = filter.Color ?? "",
            Optional = filter.Optional ?? "",
            Photos = (PhotosOption)(filter.Photos ?? 0),
        };
    }

    public static FilterModel ToFilter(RequestListVehiclesDTO request)
    {
        return new FilterModel
        {
            Plate = request.Plate,
            Brand = request.Brand,
            Model = request.Model,
            MinYear = request.MinYear,
            MaxYear = request.MaxYear,
            PriceRange = (int)(request.PriceRange ?? 0),
            Color = request.Color,
            Optional = request.Optional,
            Photos = (int)(request.Photos ?? 0),
        };
    }
}
