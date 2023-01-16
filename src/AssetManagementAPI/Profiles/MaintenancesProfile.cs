using AutoMapper;
using AssetManagementAPI.Model;
using AssetManagementAPI.Dtos;

namespace AssetManagementAPI.Profiles
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
