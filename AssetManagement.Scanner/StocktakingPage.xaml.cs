
using AssetManagement.Application.Resources.Stocktaking;
using AssetManagement.Application.Resources.User;
using AssetManagement.Scanner.Services;

namespace AssetManagement.Scanner;

public partial class StocktakingPage : ContentPage
{
    private readonly IStocktakingService _stocktakingService;

    public StocktakingPage(IStocktakingService stocktakingService)
    {
        _stocktakingService = stocktakingService;
        InitializeComponent();
        BindingContext = new GroupedStocktakingViewModel(_stocktakingService);
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
    }

    protected async override void OnDisappearing()
    {
        base.OnDisappearing();
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
            throw new NotImplementedException();
    }
}