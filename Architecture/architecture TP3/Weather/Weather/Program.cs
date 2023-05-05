using System;

using SharedWeather.Business;
using SharedWeather.Interfaces;
using SharedWeather.Entities;
using WeatherConsole;

namespace Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            IWeatherOut weatherManager;

            Console.WriteLine("Hello World weather!");
            weatherManager = new WeatherManager(new ConsumeWeather());
            var info = new WeatherConfig();
            
            info.HasPrecipitation = true;
            info.HasPression = false;
            info.HasWind = true;

            weatherManager.SetWeatherInfo(info);
            weatherManager.StartCollect();
            Console.ReadKey();
            weatherManager.StopCollect();

        }
    }
}
