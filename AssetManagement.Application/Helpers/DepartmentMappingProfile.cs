

using AssetManagement.Application.Resources;
using AssetManagement.Application.Resources.Department;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AutoMapper;

namespace AssetManagement.Application.Helpers;
public class DepartmentMappingProfile : Profile
{
    public DepartmentMappingProfile()
    {
        CreateMap<Department, DepartmentResource>();
        CreateMap<QueryResult<Department>, QueryResultResource<DepartmentResource>>();
        CreateMap<DepartmentQueryResource, DepartmentQuery>();
        CreateMap<SaveDepartmentResource, Department>()
            .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(x => x.Faculty, opt => opt.Ignore())
            .ForMember(x => x.LastModifiedUtc, opt => opt.Ignore())
            .ForMember(x => x.CreatedUtc, opt => opt.Ignore());
    }
}
