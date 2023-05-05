using Ritege.ViewModels;
using SharedWeather.Entities;
using SharedWeather.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvMweather.ViewModel
{
    public class VMWeather : ViewModelBase
    {
        #region DATA
        IWeatherOut _weather;
        VMWeatherConfig _weatherConfig;
        ObservableCollection< VMWeatherInfo> _weatherInfos;
        VMAffichageWeather _weatherValue;

        #endregion

        #region Properties

        public VMWeatherConfig VMWeatherConfig { get { return _weatherConfig; } set { _weatherConfig = value;  OnPropertyChanged(nameof(VMWeatherConfig)); } }
        public ObservableCollection<VMWeatherInfo> WeatherInfos { get { return _weatherInfos; } 
            set { _weatherInfos = value; 
                OnPropertyChanged(nameof(WeatherInfos)); } }

        public RelayCommand StartCmd { get; set; }
        public RelayCommand StopCmd { get; set; }

        #endregion

        #region Constructor

        public VMWeather(IWeatherOut weather, VMAffichageWeather weatherValue)
        {
            _weather = weather;
            _weatherValue = weatherValue;
            WeatherInfos =  _weatherValue.WeatherIndicators;
            StartCmd = new RelayCommand(Start);
            StopCmd = new RelayCommand(Stop);
            
            VMWeatherConfig = new VMWeatherConfig(new WeatherConfig());
        }
        #endregion
        private void Stop(object obj)
        {
            _weather.StopCollect();
        }

        private void Start(object obj)
        {
           _weather.SetWeatherInfo(_weatherConfig.GetConfig);
           _weather.StartCollect();
        }

        
       

    }
}
