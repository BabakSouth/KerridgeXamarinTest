using Microsoft.Extensions.Logging;
using KerridgeTask.Services;
namespace KerridgeTask
{
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

#if DEBUG
            builder.Logging.AddDebug();
#endif
            // Register services
            builder.Services.AddSingleton<TokenService>();
            builder.Services.AddSingleton<AlertService>();
            builder.Services.AddSingleton<LoadingService>();
            builder.Services.AddSingleton<LocationService>();
            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}
