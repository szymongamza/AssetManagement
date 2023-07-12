using AssetManagement.Application.Resources.Stocktaking;
using AssetManagement.Scanner.Models;
using AssetManagement.Scanner.Services;

namespace AssetManagement.Scanner;
public class GroupedStocktakingViewModel
{
    public List<StocktakingGroup> Stocktakings { get; private set; } = new List<StocktakingGroup>();

    public GroupedStocktakingViewModel()
    {
        Stocktakings.Add(new StocktakingGroup("Test1", new List<StocktakingDto>
        {
            new StocktakingDto
            {
                Id = 1,
                Name = "ELO1"
            }
        }));      
        Stocktakings.Add(new StocktakingGroup("Test2", new List<StocktakingDto>
        {
            new StocktakingDto
            {
                Id = 2,
                Name = "ELO2"
            }
        }));

    }


}
