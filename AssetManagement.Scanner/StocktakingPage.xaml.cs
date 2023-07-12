
namespace AssetManagement.Scanner;

public partial class StocktakingPage : ContentPage
{

    public StocktakingPage()
    {
        InitializeComponent();
        BindingContext = new GroupedStocktakingViewModel();
    }

}