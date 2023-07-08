
using AssetManagement.Application.Resources.AssetStocktaking;
using AssetManagement.Domain.Entities;
using AutoMapper;

namespace AssetManagement.Application.Helpers;

public class AssetStocktakingMappingProfile : Profile
{
    public AssetStocktakingMappingProfile()
    {
        CreateMap<AssetStocktaking, AssetStocktakingResource>();
    }
}
