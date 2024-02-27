using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedWeather.Entities
{
    public class WeatherInfo
    {
        public int Temperature { get; set; }
        public int Wind { get; set; }
        public int Precipitation { get; set; }
        public int Pression { get; set; }

        public override string ToString()
        {
            return    "Température : " + Temperature.ToString() + " "
                    + "Vent : " + Wind.ToString() + " "
                    + "Pression : " + Pression.ToString() + " "
                    + "Précipitation : " + Precipitation.ToString() + " ";
        }
    }
}
