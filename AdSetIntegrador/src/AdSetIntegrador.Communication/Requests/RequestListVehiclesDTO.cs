﻿using AdSetIntegrador.Communication.Enums;

namespace AdSetIntegrador.Communication.Requests;

public class RequestListVehiclesDTO {
    public string? Plate { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public int? MinYear { get; set; }
    public int? MaxYear { get; set; }
    public PriceRange? PriceRange { get; set; }
    public string? Color { get; set; }
}
