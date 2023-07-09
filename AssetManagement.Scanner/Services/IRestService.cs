using AssetManagement.Application.Resources;
using AssetManagement.Application.Resources.Stocktaking;

namespace AssetManagement.Scanner.Services
{
    public interface IRestService
    {
        Task<QueryResultResource<StocktakingResource>> GetStocktakings(StocktakingQueryResource query);

    }
}
