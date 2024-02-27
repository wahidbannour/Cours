using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.Entities;
using Weather.Domain.Services;

namespace WeatherConsole
{
    internal class WeatherDisplay : IWeatherDisplay
    {
        private WeatherConfig config;

        public WeatherDisplay(WeatherConfig config)
        {
            this.config = config;
        }

        public void Display(WeatherInfo info)
        {
            if (config.HasWind)
            {
                Console.Write("Wind : ");
                Console.WriteLine(info.Wind);
            }
            if (config.HasTemperature)
            {
                Console.Write("Temperature : ");
                Console.WriteLine(info.Temperature);
            }
            if (config.HasPrecipitation)
            {
                Console.Write("Precepitation : ");
                Console.WriteLine(info.Precipitation);
            }
            if (config.HasPression)
            {
                Console.Write("Pression : ");
                Console.WriteLine(info.Pression);
            }
        }

        public void Display(string log)
        {
            Console.WriteLine(log);
        }
    }
}
