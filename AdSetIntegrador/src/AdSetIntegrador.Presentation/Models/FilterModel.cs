namespace AdSetIntegrador.Presentation.Models
{
    public class FilterModel
    {
        public string? Plate { get; set; } = string.Empty;
        public string? Brand { get; set; } = string.Empty;
        public string? Model { get; set; } = string.Empty;
        public int? MinYear { get; set; } = 2000;
        public int? MaxYear { get; set; } = 2024;
        public int? PriceRange { get; set; } = 0;
        public string? Color { get; set; } = string.Empty;
        public string? Optional { get; set; } = string.Empty;
        public int? Photos { get; set; } = 0;
    }
}
