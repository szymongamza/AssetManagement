using AssetManagement.Api.Dtos;
using AssetManagement.Domain.Entities;
using AutoMapper;

namespace AssetManagement.Api.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<FacultyCreateDto, Faculty>()
            .ForMember(dest => dest.FacultyCode, act => act.MapFrom(src => src.FacultyCode))
            .ForMember(dest => dest.FacultyName, act => act.MapFrom(src => src.FacultyName));
    }
}