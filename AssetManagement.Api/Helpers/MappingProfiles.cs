using AssetManagement.Api.Dtos;
using AssetManagement.Domain.Entities;
using AutoMapper;

namespace AssetManagement.Api.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<FacultyCreateDto, Faculty>()
            .ForMember(dest => dest.Code, act => act.MapFrom(src => src.Code))
            .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name));
    }
}