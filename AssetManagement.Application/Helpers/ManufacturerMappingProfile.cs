
using AssetManagement.Application.Resources.Manufacturer;
using AssetManagement.Application.Resources;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AutoMapper;

namespace AssetManagement.Application.Helpers;

public class ManufacturerMappingProfile : Profile
{
	public ManufacturerMappingProfile()
	{
        CreateMap<Manufacturer, ManufacturerResource>();
        CreateMap<QueryResult<Manufacturer>, QueryResultResource<ManufacturerResource>>();
        CreateMap<ManufacturerQueryResource, ManufacturerQuery>();
        CreateMap<SaveManufacturerResource, Manufacturer>()
            .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(x => x.LastModifiedUtc, opt => opt.Ignore())
            .ForMember(x => x.CreatedUtc, opt => opt.Ignore())
            .ForMember(x => x.Assets, opt => opt.Ignore());

    }
} 
