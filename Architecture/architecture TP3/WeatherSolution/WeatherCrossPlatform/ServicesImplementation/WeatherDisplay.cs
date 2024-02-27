using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.Entities;
using Weather.Domain.Services;

namespace WeatherCrossPlatform.ServicesImplementation
{
    public class WeatherDataEventArgs: EventArgs
    {
        public WeatherInfo? DataWeather{get; private set;}

        public WeatherDataEventArgs(WeatherInfo? dataWeather)
        {
            DataWeather = dataWeather;
        }
    }
    public class WeatherLogEventArgs : EventArgs
    {
        public string MessageLog { get; private set; } = "";

        public WeatherLogEventArgs(string messageLog)
        {
            MessageLog = messageLog;
        }
    }
    public class WeatherDisplay : IWeatherDisplay
    {
        public event EventHandler<WeatherDataEventArgs>? OnDataReceived;
        public event EventHandler<WeatherLogEventArgs>? OnLogger;

        public void Display(WeatherInfo info)
        {
            if (OnDataReceived != null) OnDataReceived(this, new WeatherDataEventArgs(info));
        }

        public void Display(string log)
        {
            if(OnLogger != null) OnLogger(this, new WeatherLogEventArgs(log));
        }
    }
}
