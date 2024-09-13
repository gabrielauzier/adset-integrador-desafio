using AdSetIntegrador.Communication.Responses;
using AdSetIntegrador.Presentation.Models;

namespace AdSetIntegrador.Presentation.Mappers;

public static class OverviewMapper
{
    public static OverviewModel ToView(ResponseGetVehiclesOverviewDTO response)
    {
        return new OverviewModel
        {
            Colors = response.Colors,
            Total = response.Total,
            TotalWithImages = response.TotalWithImages,
            TotalWithoutImages = response.TotalWithoutImages
        };
    }
}
