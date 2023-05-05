using Ritege.ViewModels;
using SharedWeather.Entities;

namespace WpfMvvMweather.ViewModel
{
    public class VMWeatherInfo : ViewModelBase
    {
        private WeatherInfo _weatherInfo;

        public int Pression { get => _weatherInfo.Pression; set { _weatherInfo.Pression = value;OnPropertyChanged(nameof(Pression)); } }
        public int Wind { get => _weatherInfo.Wind; set { _weatherInfo.Wind = value; OnPropertyChanged(nameof(Wind)); } }
        public int Precipitation { get => _weatherInfo.Precipitation; set { _weatherInfo.Precipitation = value; OnPropertyChanged(nameof(Precipitation)); } }
        public int Temperature { get => _weatherInfo.Temperature; set { _weatherInfo.Temperature = value; OnPropertyChanged(nameof(Temperature)); } }


        public VMWeatherInfo() {
            _weatherInfo = new WeatherInfo();
        }

        public override string? ToString()
        {
            return _weatherInfo.ToString();
        }
    }
}