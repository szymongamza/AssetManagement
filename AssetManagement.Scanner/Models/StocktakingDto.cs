namespace AssetManagement.Scanner.Models;

public class StocktakingDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return Name;
    }
}



