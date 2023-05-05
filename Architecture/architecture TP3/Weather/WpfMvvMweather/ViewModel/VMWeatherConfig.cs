using Ritege.ViewModels;
using SharedWeather.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvMweather.ViewModel
{
    public class VMWeatherConfig : ViewModelBase
    {
        WeatherConfig config;
        public bool HasPrecipitation { 
            get { return config.HasPrecipitation; }
            set { config.HasPrecipitation = value; OnPropertyChanged(nameof(HasPrecipitation)); }
        }
        public bool HasWind
        {
            get { return config.HasWind; }
            set { config.HasWind = value; OnPropertyChanged(nameof(HasWind)); }
        }
        public bool HasPression
        {
            get { return config.HasPression; }
            set { config.HasPression = value; OnPropertyChanged(nameof(HasPression)); }
        }
        public bool HasTemperature
        {
            get { return config.HasTemperature; }
            set { config.HasTemperature = value; OnPropertyChanged(nameof(HasTemperature)); }
        }

        public WeatherConfig GetConfig { get { return config; } }
        public VMWeatherConfig(WeatherConfig config)
        {
            this.config = config;
        }
    }
}
