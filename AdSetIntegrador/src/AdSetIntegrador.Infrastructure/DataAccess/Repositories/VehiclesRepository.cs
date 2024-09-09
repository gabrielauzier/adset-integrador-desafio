using AdSetIntegrador.Domain.Entities;
using AdSetIntegrador.Domain.Repositories;

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
}
