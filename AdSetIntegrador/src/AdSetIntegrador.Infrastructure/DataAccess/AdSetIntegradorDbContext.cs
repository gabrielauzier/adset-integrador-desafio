using AdSetIntegrador.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdSetIntegrador.Infrastructure.DataAccess;

internal class AdSetIntegradorDbContext : DbContext
{
    public AdSetIntegradorDbContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Image> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicle>()
            .HasMany(v => v.Images)
            .WithOne(i => i.Vehicle)
            .HasForeignKey(i => i.VehicleId);
    }
}
