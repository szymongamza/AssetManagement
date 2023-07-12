using AssetManagement.Application.Resources.Stocktaking;

namespace AssetManagement.Scanner.Models;
public class StocktakingGroup : List<StocktakingDto>
{
    public string Name { get; private set; }

    public StocktakingGroup(string name, List<StocktakingDto> stocktakings) : base(stocktakings)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}
