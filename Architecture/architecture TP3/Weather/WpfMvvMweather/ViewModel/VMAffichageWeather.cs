using Ritege.ViewModels;
using SharedWeather.Entities;
using SharedWeather.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WpfMvvMweather.ViewModel
{
    public class VMAffichageWeather : ViewModelBase, IWeatherIn
    {
        delegate void OneArgDelegate(WeatherInfo info);

        private ObservableCollection< VMWeatherInfo> _weatherIndicators;
        public ObservableCollection<VMWeatherInfo> WeatherIndicators { get => _weatherIndicators; 
            set {
                _weatherIndicators = value; 
                OnPropertyChanged(nameof(WeatherIndicators)); 
            } 
        }
        public VMAffichageWeather()
        {
            _weatherIndicators = new ObservableCollection<VMWeatherInfo> ();
        }

       
        public void WriteWeather(WeatherInfo weatherInfo)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(()=> {
                WeatherIndicators.Add(new VMWeatherInfo
                {
                    Precipitation = weatherInfo.Precipitation,
                    Temperature = weatherInfo.Temperature,
                    Wind = weatherInfo.Wind,
                    Pression = weatherInfo.Pression
                });
            }), DispatcherPriority.Background);   
        }

        

        public void WriteWeatherValue(string valueType, string value)
        {
            //throw new NotImplementedException();
        }
    }
}
