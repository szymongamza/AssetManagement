using AssetManagement.Application.Dtos;
using AssetManagement.Domain.Entities;
using AutoMapper;

namespace AssetManagement.Application.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<FacultyCreateDto, Faculty>()
            .ForMember(dest => dest.Code, act => act.MapFrom(src => src.Code))
            .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name));

        CreateMap<DepartmentCreateDto, Department>()
            .ForMember(dest => dest.Code, act => act.MapFrom(src => src.Code))
            .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
            .ForMember(dest => dest.FacultyId, act => act.MapFrom(src => src.FacultyId));
    }
}