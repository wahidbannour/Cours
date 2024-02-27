using System;
using System.Collections.Generic;
using System.Text;
using Weather.Domain.Entities;

namespace Weather.Domain.Services
{
    public interface IWeatherManager // IWeatherOut : Service fourni
    {
        void StartCollect();
        void StopCollect();
        WeatherConfig GetConfig();
        void SetConfig(WeatherConfig config);
    }
}
