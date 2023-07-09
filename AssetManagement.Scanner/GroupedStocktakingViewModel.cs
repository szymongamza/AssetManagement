using AssetManagement.Scanner.Models;
using AssetManagement.Scanner.Services;

namespace AssetManagement.Scanner;
public class GroupedStocktakingViewModel
{
    private readonly IStocktakingService _stocktakingService;
    public List<GroupedStocktaking> Stocktakings { get; private set; } = new List<GroupedStocktaking>();

    public GroupedStocktakingViewModel(IStocktakingService stocktakingService)
    {
        _stocktakingService = stocktakingService;
        GetStocktakings();
    }

    async void GetStocktakings()
    {
        Stocktakings = await _stocktakingService.GetStocktakings();
    }

}
