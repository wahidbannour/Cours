using System;
using System.Collections.Generic;
using System.Text;
using Weather.Domain.Entities;

namespace Weather.Domain.Services
{
    public interface IWeatherDisplay // IWeatherIn : service demandé
    {
        void Display(WeatherInfo info);
        void Display(string log);
    }
}
