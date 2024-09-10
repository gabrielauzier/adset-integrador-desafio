using AdSetIntegrador.Domain.Entities;
using AdSetIntegrador.Domain.Repositories;
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

    public Vehicle? GetById(int vehicleId)
    {
        return _dbContext.Vehicles.FirstOrDefault(v => v.Id == vehicleId);
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}
