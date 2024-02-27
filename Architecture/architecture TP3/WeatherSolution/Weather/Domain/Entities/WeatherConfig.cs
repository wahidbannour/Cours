using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Domain.Entities
{
    public class WeatherConfig
    {
        public bool HasTemperature { get; set; }
        public bool HasWind { get; set; }
        public bool HasPrecipitation { get; set; }
        public bool HasPression { get; set; }
    }
}
