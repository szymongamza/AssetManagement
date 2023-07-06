
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
        CreateMap<Stocktaking, StocktakingResource>().ForMember(dest => dest.Assets, opt => opt.MapFrom(src => src.AssetStocktakings));
        CreateMap<QueryResult<Stocktaking>, QueryResultResource<StocktakingResource>>();
        CreateMap<StocktakingQueryResource, StocktakingQuery>();
    }
}
