using AssetManagement.Application.Resources;
using AssetManagement.Application.Resources.Faculty;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AutoMapper;

namespace AssetManagement.Application.Helpers;
public class FacultyMappingProfile : Profile
{
    public FacultyMappingProfile()
    {
        CreateMap<Faculty, FacultyResource>();
        CreateMap<QueryResult<Faculty>, QueryResultResource<FacultyResource>>();
        CreateMap<FacultyQueryResource, FacultyQuery>();
        CreateMap<SaveFacultyResource, Faculty>()
            .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(x => x.LastModifiedUtc, opt => opt.Ignore())
            .ForMember(x => x.CreatedUtc, opt => opt.Ignore())
            .ForMember(x => x.Buildings, opt => opt.Ignore())
            .ForMember(x => x.Departments, opt => opt.Ignore());

    }
}
