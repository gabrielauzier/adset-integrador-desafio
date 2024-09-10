﻿using AdSetIntegrador.Domain.Entities;

namespace AdSetIntegrador.Domain.Repositories;

public interface IVehiclesRepository
{
    void Create(Vehicle vehicle);
    Vehicle? GetById(int vehicleId);
    void Save();
}
