using AdSetIntegrador.Communication.Requests;
using AdSetIntegrador.Domain.Entities;
using AdSetIntegrador.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using AdSetIntegrador.Infrastructure.Helpers;
using AdSetIntegrador.Communication.Enums;

namespace AdSetIntegrador.Infrastructure.DataAccess.Repositories;

internal class VehiclesRepository : IVehiclesRepository
{
    private readonly AdSetIntegradorDbContext _dbContext;

    public VehiclesRepository(AdSetIntegradorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(Vehicle vehicle)
    {
        _dbContext.Vehicles.Add(vehicle);
        _dbContext.SaveChanges();
    }

    public void Delete(Vehicle vehicle)
    {
        _dbContext.Vehicles.Remove(vehicle);
        _dbContext.SaveChanges();
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public Vehicle? GetById(int vehicleId)
    {
        return _dbContext.Vehicles.FirstOrDefault(v => v.Id == vehicleId);
    }

    public List<Vehicle> List(RequestListVehiclesDTO request)
    {
        var result = _dbContext.Vehicles
            .Filter(!String.IsNullOrEmpty(request.Plate), v => v.Plate.Contains(request.Plate ?? ""))
            .Filter(!String.IsNullOrEmpty(request.Color), v => v.Color.Contains(request.Color ?? ""))
            .Filter(!String.IsNullOrEmpty(request.Brand), v => v.Brand.Contains(request.Brand ?? ""))
            .Filter(!String.IsNullOrEmpty(request.Model), v => v.Model.Contains(request.Model ?? ""))
            .Filter(request.MinYear.HasValue, v => v.Year >= request.MinYear)
            .Filter(request.MaxYear.HasValue, v => v.Year <= request.MaxYear)
            .Filter(request.PriceRange == PriceRange.Low, v => v.Price >= 10 * 1000 && v.Price <= 50 * 1000)
            .Filter(request.PriceRange == PriceRange.Medium, v => v.Price >= 50 * 1000 && v.Price <= 90 * 1000)
            .Filter(request.PriceRange == PriceRange.High, v => v.Price >= 90 * 1000)
            .AsQueryable();

        /*
        */
        return result.ToList();
    }
}
