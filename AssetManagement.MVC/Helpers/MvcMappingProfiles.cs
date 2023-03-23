using AssetManagement.Application.Helpers;
using AssetManagement.Domain.Entities;
using AssetManagement.MVC.Models;
using AutoMapper;

namespace AssetManagement.MVC.Helpers;

public class MvcMappingProfiles : Profile
{
    public MvcMappingProfiles()
    {
        CreateMap<BuildingViewModel, Building>()
            .ForMember(dest => dest.Code, act => act.MapFrom(src => src.Code))
            .ForMember(dest => dest.City, act => act.MapFrom(src => src.City))
            .ForMember(dest => dest.PostCode, act => act.MapFrom(src => src.PostCode))
            .ForMember(dest => dest.Street, act => act.MapFrom(src => src.Street));
        CreateMap<Building, BuildingViewModel>()
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
            .ForMember(dest => dest.Code, act => act.MapFrom(src => src.Code))
            .ForMember(dest => dest.City, act => act.MapFrom(src => src.City))
            .ForMember(dest => dest.PostCode, act => act.MapFrom(src => src.PostCode))
            .ForMember(dest => dest.Street, act => act.MapFrom(src => src.Street));
    }
}