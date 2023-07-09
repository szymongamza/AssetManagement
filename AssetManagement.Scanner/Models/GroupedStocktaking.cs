using AssetManagement.Application.Resources.Stocktaking;

namespace AssetManagement.Scanner.Models;
public class GroupedStocktaking
{
    public string GroupName { get; set; }
    public List<StocktakingResource> stocktaking { get; set; }
}
