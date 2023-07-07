
using AssetManagement.Application.Resources;
using AssetManagement.Application.Resources.Stocktaking;
using AssetManagement.Domain.Common.Query;
using AssetManagement.Domain.Entities;
using AutoMapper;

namespace StocktakingManagement.Application.Helpers;

public class StocktakingMappingProfile : Profile
{
    public StocktakingMappingProfile()
    {
        CreateMap<Stocktaking, StocktakingResource>()
            .ForMember(dest => dest.Assets, opt => opt.MapFrom(src => src.AssetStocktakings))
            .ForMember(dest => dest.TotalAssets, m => m.MapFrom(src => src.Assets.Count()))
            .ForMember(dest => dest.ScannedAssets, m => m.MapFrom(src => src.AssetStocktakings.Where(x=> x.IsScanned == true).Count()));
            
        CreateMap<QueryResult<Stocktaking>, QueryResultResource<StocktakingResource>>();
        CreateMap<StocktakingQueryResource, StocktakingQuery>();
    }
}


