using AssetManagement.Server.Dtos.MaintenanceDtos;
using AssetManagement.Server.Model;
using AutoMapper;

namespace AssetManagement.Server.Profiles
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
