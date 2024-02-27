using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.Entities;
using Weather.Domain.Services;
using WeatherCrossPlatform.ServicesImplementation;

namespace WeatherCrossPlatform.ViewModel
{
    public class WeatherManagerVM : ObservableObject,IDisposable
    {
        #region DATA
        private readonly IWeatherDisplay display;
        private readonly IWeatherManager weather;
        private WeatherInfo info = new WeatherInfo();
        private WeatherConfig config = new WeatherConfig();
        private bool isStarted = false;
        #endregion

        #region Properties

        public bool IsStarted
        {
            get => isStarted;
            set
            {
                SetProperty(ref isStarted, value);
                StartCommand.NotifyCanExecuteChanged();
                StopCommand.NotifyCanExecuteChanged();
            }
        }
        public bool HasPrecipitation
        {
            get => config.HasPrecipitation;
            set {
                config.HasPrecipitation = value;
                OnPropertyChanged(nameof(HasPrecipitation));
            }
        }
        public bool HasPression
        {
            get => config.HasPression;
            set
            {
                config.HasPression = value;
                OnPropertyChanged(nameof(HasPression));
            }
        }
        public bool HasWind
        {
            get => config.HasWind;
            set
            {
                config.HasWind = value;
                OnPropertyChanged(nameof(HasWind));
            }
        }
        public bool HasTemperature
        {
            get => config.HasTemperature;
            set
            {
                config.HasTemperature = value;
                OnPropertyChanged(nameof(HasTemperature));
            }
        }
        public int Precipitation
        {
            get => info.Precipitation;
            set => OnPropertyChanged(nameof(Precipitation));
        }
        public int Temperature
        {
            get => info.Temperature;
            set => OnPropertyChanged(nameof(Temperature));
        }
        public int Wind
        {
            get => info.Wind;
            set => OnPropertyChanged(nameof(Wind));
        }
        public int Pression
        {
            get => info.Pression;
            set => OnPropertyChanged(nameof(Pression));
        }
        #endregion

        #region Command
        public IRelayCommand BackCommand { get; private set; }
        public IRelayCommand StartCommand { get; private set; }
        public IRelayCommand StopCommand { get; private set; }
        
        #endregion

        #region CTOR
        public WeatherManagerVM(IWeatherManager weather, IWeatherDisplay display)
        {
            this.weather = weather;
            this.display = display;
            ((WeatherDisplay)display).OnDataReceived += WeatherManagerVM_OnDataReceived;
            ((WeatherDisplay)display).OnLogger += WeatherManagerVM_OnLogger; ;
            BackCommand = new AsyncRelayCommand(GoBack);
            StartCommand = new RelayCommand(Start, CanStart);
            StopCommand = new RelayCommand(Stop, CanStop);
        }

        #endregion

        #region CAN
        private bool CanStop()
        {
            return isStarted;
        }

        private bool CanStart()
        {
            return !isStarted;
        }
        #endregion

        #region METHOD
        private async Task GoBack()
        {
            weather.StopCollect();
            await Shell.Current.GoToAsync("//MainPage");
        }
        private void Stop()
        {
            weather.StopCollect();
            IsStarted = false;

        }

        private void Start()
        {
            weather.SetConfig(config);
            weather.StartCollect();
            IsStarted = true;
        }

        private void WeatherManagerVM_OnLogger(object? sender, WeatherLogEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void WeatherManagerVM_OnDataReceived(object? sender, WeatherDataEventArgs e)
        {
            info = e.DataWeather!;
            Pression = info.Pression;
            Temperature = info.Temperature;
            Precipitation = info.Precipitation;
            Wind = info.Wind;
        }

        public void Dispose()
        {
            if(display != null)
            {
                ((WeatherDisplay)display).OnDataReceived -= WeatherManagerVM_OnDataReceived;
                ((WeatherDisplay)display).OnLogger -= WeatherManagerVM_OnLogger;
            }
        }

        #endregion
    }
}
