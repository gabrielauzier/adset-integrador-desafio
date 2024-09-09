﻿namespace AdSetIntegrador.Domain.Entities;

public class Vehicle
{
    public int Id { get; set; }
    public string Brand {  get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Plate { get; set; } = string.Empty;
    public int? Mileage { get; set; }
    public string Color {  get; set; } = string.Empty;
    public decimal Price { get; set; }
}
