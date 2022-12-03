using AutoMapper;
using Localisation.API.Model;
using Localisation.API.Dtos;

namespace Localisation.API.Profiles
{
    public class MaintenancesProfile : Profile
    {
        public MaintenancesProfile()
        {
            CreateMap<Maintenance, MaintenanceReadDto>();
            CreateMap<MaintenanceCreateDto, Maintenance>();
        }
    }
}
