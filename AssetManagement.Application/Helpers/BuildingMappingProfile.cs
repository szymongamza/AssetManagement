using AssetManagement.Application.Resources;
using AssetManagement.Application.Resources.Building;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AutoMapper;

namespace AssetManagement.Application.Helpers;
public class BuildingMappingProfile : Profile
{
    public BuildingMappingProfile()
    {
        CreateMap<Building, BuildingResource>();
        CreateMap<QueryResult<Building>, QueryResultResource<BuildingResource>>();
        CreateMap<BuildingQueryResource, BuildingQuery>();

        CreateMap<SaveBuildingResource, Building>()
            .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(x => x.Rooms, opt => opt.Ignore())
            .ForMember(x => x.LastModifiedUtc, opt => opt.Ignore())
            .ForMember(x => x.CreatedUtc, opt => opt.Ignore())
            .ForMember(c => c.Faculties, m => m.MapFrom(l => CreateFaculties(l.FacultiesIds)));
    }

    private static List<Faculty> CreateFaculties(ICollection<int> facultiesIds)
    {
        IList<Faculty> faculties = new List<Faculty>();

        foreach (int id in facultiesIds)
        {
            faculties.Add(new Faculty
            {
                Id = id
            });
        }

        return faculties.ToList();
    }
}
