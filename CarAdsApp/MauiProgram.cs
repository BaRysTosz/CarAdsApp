using Microsoft.Extensions.Logging;
using CarAdsApp.BazaDanych;
using CarAdsApp.ModeleWidokow;
using CarAdsApp.Serwisy;
using CarAdsApp.Widoki;

namespace CarAdsApp;

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
            });

        builder.Services.AddSingleton<BazaSQLite>();
        builder.Services.AddSingleton<SerwisApi>();

        builder.Services.AddSingleton<StronaGlownaWidokModel>();
        builder.Services.AddSingleton<DodajOgloszenieWidokModel>();

        builder.Services.AddSingleton<StronaGlowna>();
        builder.Services.AddSingleton<StronaDodawania>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}