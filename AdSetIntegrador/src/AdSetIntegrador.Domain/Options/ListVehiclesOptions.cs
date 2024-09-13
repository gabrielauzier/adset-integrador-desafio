using AdSetIntegrador.Domain.Enums;

namespace AdSetIntegrador.Domain.Options;

public class ListVehiclesOptions
{
    public string? Plate { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public int? MinYear { get; set; }
    public int? MaxYear { get; set; }
    public PriceRange? PriceRange { get; set; }
    public string? Color { get; set; }
    public string? Optional { get; set; }
    public PhotosOption? Photos { get; set; }
}
