using AutoMapper;
using AdSetIntegrador.Domain.Entities;
using AdSetIntegrador.Presentation.Models;

namespace AdSetIntegrador.Presentation.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        ToViewModel();
    }

    private void ToViewModel()
    {
        CreateMap<IEnumerable<Vehicle>, IEnumerable<VehicleModel>>();
    }
}

