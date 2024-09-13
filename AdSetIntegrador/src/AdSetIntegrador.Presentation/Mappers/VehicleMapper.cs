using AdSetIntegrador.Communication.Requests;
using AdSetIntegrador.Domain.Entities;
using AdSetIntegrador.Presentation.Models;

namespace AdSetIntegrador.Presentation.Mappers;

public static class VehicleMapper
{
    public static VehicleModel ToView(Vehicle vehicle) {
        return new VehicleModel
        {
            Brand = vehicle.Brand,
            Color = vehicle.Color,
            Id = vehicle.Id,
            Mileage = vehicle.Mileage,
            Model = vehicle.Model,
            Plate = vehicle.Plate,
            Price = vehicle.Price,
            Year = vehicle.Year
        };
    }

    public static RequestRegisterVehicleJson ToRegister(VehicleModel vehicle)
    {
        return new RequestRegisterVehicleJson
        {
            Brand = vehicle.Brand,
            Color = vehicle.Color,
            Mileage = vehicle.Mileage,
            Model = vehicle.Model,
            Plate = vehicle.Plate,
            Price = vehicle.Price,
            Year = vehicle.Year
        };
    }

    public static RequestUpdateVehicleJson ToUpdate(VehicleModel vehicle)
    {
        return new RequestUpdateVehicleJson
        {
            Id = vehicle.Id,
            Brand = vehicle.Brand,
            Color = vehicle.Color,
            Mileage = vehicle.Mileage,
            Model = vehicle.Model,
            Plate = vehicle.Plate,
            Price = vehicle.Price,
            Year = vehicle.Year,
        };
    }

    public static List<VehicleModel> ToViewList(List<Vehicle> vehicles)
    {
        return vehicles.Select(vehicle => new VehicleModel
         {
             Brand = vehicle.Brand,
             Color = vehicle.Color,
             Id = vehicle.Id,
             Mileage = vehicle.Mileage,
             Model = vehicle.Model,
             Plate = vehicle.Plate,
             Price = vehicle.Price,
             Year = vehicle.Year
         }).ToList();
    }
}
