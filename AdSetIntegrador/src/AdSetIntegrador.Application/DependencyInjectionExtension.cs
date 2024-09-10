using AdSetIntegrador.Application.UseCases.Vehicles.Register;
using AdSetIntegrador.Application.UseCases.Vehicles.Update;
using Microsoft.Extensions.DependencyInjection;

namespace AdSetIntegrador.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRegisterVehicleUseCase, RegisterVehicleUseCase>();
        services.AddScoped<IUpdateVehicleUseCase, UpdateVehicleUseCase>();
    }
}
