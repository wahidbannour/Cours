using Weather.Domain.Entities;
using Weather.Business;

namespace WeatherConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, weather");
            var config = new WeatherConfig();
            var weather = new WeatherManager(new WeatherDisplay(config));
            Console.WriteLine("configure weather component");
            Console.Write("Get Temperature? (Y/N) ");
            var result = Console.ReadLine();
            if (result == "Y") 
                config.HasTemperature = true;   
            else
                config.HasTemperature = false;
            Console.Write("Get Pression? (Y/N) ");
            result = Console.ReadLine();
            if (result == "Y")
                config.HasPression = true;
            else
                config.HasPression = false;
            Console.Write("Get Wind? (Y/N) ");
            result = Console.ReadLine();
            if (result == "Y")
                config.HasWind = true;
            else
                config.HasWind = false;
            Console.Write("Get Precepitation? (Y/N) ");
            result = Console.ReadLine();
            if (result == "Y")
                config.HasPrecipitation = true;
            else
                config.HasPrecipitation = false;

            weather.SetConfig(config);
            weather.StartCollect();
            Console.ReadKey();

        }
    }
}
