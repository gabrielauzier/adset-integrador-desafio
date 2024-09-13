using AdSetIntegrador.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdSetIntegrador.Infrastructure.Migrations;
public static class DatabaseMigration
{
    public async static Task MigrateDatabase(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<AdSetIntegradorDbContext>();

        await dbContext.Database.MigrateAsync();
    }
}