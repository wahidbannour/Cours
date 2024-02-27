using SharedWeather.Entities;
using SharedWeather.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherConsole
{
    class ConsumeWeather : IWeatherIn
    {
        public void WriteWeather(WeatherInfo weatherInfo)
        {
            Console.WriteLine("Précipitation =  " +  weatherInfo.Precipitation);
            Console.WriteLine("Température =  " + weatherInfo.Temperature);
            Console.WriteLine("Vent =  " + weatherInfo.Wind);
            Console.WriteLine("Pression =  " + weatherInfo.Pression);
        }

        public void WriteWeatherValue(string valueType, string value)
        {
            Console.WriteLine("pour la " + valueType + " : " + value);
        }

    }
}
