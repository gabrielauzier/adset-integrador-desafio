using AdSetIntegrador.Domain.Entities;
using AdSetIntegrador.Domain.Repositories;
using AdSetIntegrador.Infrastructure.Helpers;
using AdSetIntegrador.Domain.Options;
using AdSetIntegrador.Domain.Enums;
using Microsoft.EntityFrameworkCore;

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
        return _dbContext.Vehicles.Include(v => v.Images).FirstOrDefault(v => v.Id == vehicleId);
    }

    public List<Vehicle> List(ListVehiclesOptions options)
    {
        var result = _dbContext.Vehicles
            .Include(v => v.Images)
            .Filter(!String.IsNullOrEmpty(options.Plate), v => v.Plate.Contains(options.Plate ?? ""))
            .Filter(!String.IsNullOrEmpty(options.Color), v => v.Color.Contains(options.Color ?? ""))
            .Filter(!String.IsNullOrEmpty(options.Brand), v => v.Brand.Contains(options.Brand ?? ""))
            .Filter(!String.IsNullOrEmpty(options.Model), v => v.Model.Contains(options.Model ?? ""))
            .Filter(options.MinYear.HasValue, v => v.Year >= options.MinYear)
            .Filter(options.MaxYear.HasValue, v => v.Year <= options.MaxYear)
            .Filter(options.PriceRange == PriceRange.Low, v => v.Price >= 10 * 1000 && v.Price <= 50 * 1000)
            .Filter(options.PriceRange == PriceRange.Medium, v => v.Price >= 50 * 1000 && v.Price <= 90 * 1000)
            .Filter(options.PriceRange == PriceRange.High, v => v.Price >= 90 * 1000)
            .Filter(options.Photos == PhotosOption.WithPhotos, v => v.Images.Count() > 0)
            .Filter(options.Photos == PhotosOption.NoPhotos, v => v.Images.Count() == 0)
            
            .AsQueryable();

        /*
        */
        return result.ToList();
    }
}
