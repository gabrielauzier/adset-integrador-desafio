using AdSetIntegrador.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdSetIntegrador.Infrastructure.DataAccess;

internal class AdSetIntegradorDbContext : DbContext
{
    public AdSetIntegradorDbContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Vehicle> Vehicles { get; set; }
}
