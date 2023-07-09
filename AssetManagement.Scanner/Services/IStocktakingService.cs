
using AssetManagement.Application.Resources.Stocktaking;
using AssetManagement.Application.Resources;
using AssetManagement.Scanner.Models;

namespace AssetManagement.Scanner.Services;
public interface IStocktakingService
{
    Task<List<GroupedStocktaking>> GetStocktakings();
}
