namespace AdSetIntegrador.Domain.Entities;

public class Image
{
    public int Id { get; set; } 
    public string Name { get; set; } 
    public string Description { get; set; } 
    public byte[] Raw { get; set; } 
    public string ContentType { get; set; }

    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
}