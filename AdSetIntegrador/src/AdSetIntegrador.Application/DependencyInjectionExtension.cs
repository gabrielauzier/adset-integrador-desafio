using AdSetIntegrador.Application.UseCases.Vehicles.Delete;
using AdSetIntegrador.Application.UseCases.Vehicles.GetById;
using AdSetIntegrador.Application.UseCases.Vehicles.GetVehicleById;
using AdSetIntegrador.Application.UseCases.Vehicles.List;
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
        services.AddScoped<IDeleteVehicleUseCase, DeleteVehicleUseCase>();
        services.AddScoped<IListVehiclesUseCase, ListVehiclesUseCase>();
        services.AddScoped<IGetVehicleByIdUseCase, GetVehicleByIdUseCase>();
    }
}
