using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Domain.Entities
{
    public class WeatherInfo
    {
        public int Temperature { get; set; }
        public int Wind { get; set; }
        public int Precipitation { get; set; }
        public int Pression { get; set; }

    }
}
