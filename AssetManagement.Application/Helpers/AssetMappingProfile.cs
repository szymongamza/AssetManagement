
using AssetManagement.Application.Resources.Asset;
using AssetManagement.Application.Resources;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AutoMapper;

namespace AssetManagement.Application.Helpers
{
    public class AssetMappingProfile : Profile
    {
        public AssetMappingProfile()
        {
            CreateMap<Asset, AssetResource>();
            CreateMap<QueryResult<Asset>, QueryResultResource<AssetResource>>();
            CreateMap<AssetQueryResource, AssetQuery>();
            CreateMap<SaveAssetResource, Asset>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Manufacturer, opt => opt.Ignore())
                .ForMember(x => x.Room, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedUtc, opt => opt.Ignore())
                .ForMember(x => x.CreatedUtc, opt => opt.Ignore());
        }
    }
}
