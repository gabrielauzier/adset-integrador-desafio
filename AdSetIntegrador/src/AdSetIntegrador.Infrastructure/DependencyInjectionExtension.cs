using AdSetIntegrador.Domain.Repositories;
using AdSetIntegrador.Infrastructure.DataAccess;
using AdSetIntegrador.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdSetIntegrador.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbSqlServerContext(services, configuration);
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IVehiclesRepository, VehiclesRepository>();
    }

    private static void AddDbSqlServerContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ConnectionSqlServer");

        services.AddDbContext<AdSetIntegradorDbContext>(config => config.UseSqlServer(connectionString));
    }
}
