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
            Year = vehicle.Year,
            Optional = vehicle.Optional ?? ""
        };
    }

    public static RequestRegisterVehicleJson ToRegister(VehicleModel vehicle, ICollection<Image>? images)
    {
        return new RequestRegisterVehicleJson
        {
            Brand = vehicle.Brand,
            Color = vehicle.Color,
            Mileage = vehicle.Mileage,
            Model = vehicle.Model,
            Plate = vehicle.Plate,
            Price = vehicle.Price,
            Year = vehicle.Year,
            Images = images ?? [],
            Optional = vehicle.Optional ?? "",
        };
    }

    public static RequestUpdateVehicleJson ToUpdate(VehicleModel vehicle, ICollection<Image>? images)
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
            Images = images ?? [],
            Optional = vehicle.Optional ?? "",
        };
    }

    public static List<VehicleModel> VehiclesToListView(List<Vehicle> vehicles)
    {

        return vehicles.Select(vehicle =>
        {
            string imgBase64 = null;

            var imgRaw = vehicle.Images.FirstOrDefault()?.Raw;
            var contentType = vehicle.Images.FirstOrDefault()?.ContentType;

            if (imgRaw != null)
            {
                imgBase64 = Convert.ToBase64String(imgRaw);
            }

            return new VehicleModel
            {
                Brand = vehicle.Brand,
                Color = vehicle.Color,
                Id = vehicle.Id,
                Mileage = vehicle.Mileage,
                Model = vehicle.Model,
                Plate = vehicle.Plate,
                Price = vehicle.Price,
                Year = vehicle.Year,
                Images = vehicle.Images,
                ImgBase64 = imgBase64,
                ImgContentType = contentType,
                Optional = vehicle.Optional
            };
        }).ToList();
    }

    public static ListViewModel ToListView(List<Vehicle> vehicles)
    {
        return new ListViewModel
        {
            Filter = null,
            Vehicles = VehiclesToListView(vehicles)
        };
    }
}
