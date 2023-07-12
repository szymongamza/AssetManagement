using AssetManagement.Scanner.Services;
using Microsoft.Extensions.Logging;

namespace AssetManagement.Scanner;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("fa_solid.ttf", "FontAwesome");
            });
        builder.Services.AddSingleton<IRestService, RestService>();
        builder.Services.AddSingleton<IHttpsClientHandlerService, HttpsClientHandlerService>();
        builder.Services.AddSingleton<IStocktakingService, StocktakingService>();
#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
