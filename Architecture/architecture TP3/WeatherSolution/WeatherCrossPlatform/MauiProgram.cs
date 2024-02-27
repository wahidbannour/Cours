using Microsoft.Extensions.Logging;
using Weather.Business;
using Weather.Domain.Services;
using WeatherCrossPlatform.ServicesImplementation;

namespace WeatherCrossPlatform
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
                })
                .RegisterAppServices();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<IWeatherDisplay, WeatherDisplay>();
            mauiAppBuilder.Services.AddSingleton<IWeatherManager, WeatherManager>();
            mauiAppBuilder.Services.AddTransient<ViewModel.WeatherManagerVM>();
            return mauiAppBuilder;
        }
    }
}
