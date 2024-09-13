using AdSetIntegrador.Domain.Entities;
using AdSetIntegrador.Domain.Options;

namespace AdSetIntegrador.Domain.Repositories;

public interface IVehiclesRepository
{
    void Create(Vehicle vehicle);
    void Delete(Vehicle vehicle);
    void Save();
    Vehicle? GetById(int vehicleId);
    List<Vehicle> List(ListVehiclesOptions options);
}
