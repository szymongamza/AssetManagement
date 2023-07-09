
using AssetManagement.Application.Resources.Stocktaking;
using AssetManagement.Scanner.Models;

namespace AssetManagement.Scanner.Services;
public class StocktakingService : IStocktakingService
{
    private readonly IRestService _restService;

    public StocktakingService(IRestService restService)
    {
        _restService = restService;
    }

    public async Task<List<GroupedStocktaking>> GetStocktakings()
    {
        var stocktakings = new List<GroupedStocktaking>();
        var query = new StocktakingQueryResource { IsClosed = false, ItemsPerPage = 999, Page = 1 };
        var response = await _restService.GetStocktakings(query);
        var listRes = response.Items;
        var groupedStocktakings = listRes
            .GroupBy(s=>s.Room.Building.Id)
            .Select(grp=>grp.ToList())
            .ToList();
        foreach (var list in groupedStocktakings)
        {
            var grouped = new GroupedStocktaking
            {
                GroupName = list.FirstOrDefault().Room.Building.Code, stocktaking = list
            };
            stocktakings.Add(grouped);
        }

        return stocktakings;
    }
}
