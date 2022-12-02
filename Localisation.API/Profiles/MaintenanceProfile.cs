using AutoMapper;
using Localisation.API.Model;
using Localisation.API.Dtos;

namespace Localisation.API.Profiles
{
    public class MaintenanceProfile : Profile
    {
        public MaintenanceProfile()
        {
            CreateMap<Maintenance, MaintenanceReadDto>();
            CreateMap<MaintenanceCreateDto, Maintenance>();
        }
    }
}
