using System;
using System.Collections.Generic;
using System.Text;
using SharedWeather.Entities;

namespace SharedWeather.Interfaces
{
    public interface IWeatherIn // IPrint
    {
        void WriteWeatherValue(string valueType, string value);
        void WriteWeather(WeatherInfo weatherInfo);
    }

    public interface IWeatherOut // IWeatherManager
    {
        WeatherConfig GetWeatherInfo();

        void SetWeatherInfo(WeatherConfig info);
        void StartCollect();
        void StopCollect();
    }
}
