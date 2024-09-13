using AdSetIntegrador.Domain.Entities;

namespace AdSetIntegrador.Communication.Requests;

public class RequestUpdateVehicleJson
{
    public int Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Plate { get; set; } = string.Empty;
    public int? Mileage { get; set; }
    public string Color { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? Optional { get; set;  }
    public ICollection<Image> Images { get; set; } = [];
}
