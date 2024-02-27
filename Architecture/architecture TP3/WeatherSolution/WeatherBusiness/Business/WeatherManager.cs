using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Weather.Domain.Entities;
using Weather.Domain.Services;

namespace Weather.Business
{
    public class WeatherManager : IWeatherManager
    {

        #region DATA

        private IWeatherDisplay serviceDisplay;
        private WeatherConfig config;
        private WeatherInfo info;
        Timer polling;
        Random random;

        #endregion

        #region CTOR

        public WeatherManager(IWeatherDisplay serviceDisplay)
        {
            this.serviceDisplay = serviceDisplay;
            polling = new Timer(Poll);
            info = new WeatherInfo();
            random = new Random();
        }

        #endregion

        #region METHODS

        private void Poll(object state)
        {
            if (config == null) return;
            if (config.HasTemperature)
            {
                info.Temperature = random.Next(-15,50);
            }
            if (config.HasWind)
            {
                info.Wind = random.Next(0,150);
            }
            if (config.HasPrecipitation)
            {
                info.Precipitation = random.Next(0,200);
            }
            if (config.HasPression)
            {
                info.Pression= random.Next(10,1200);
            }
            serviceDisplay.Display(info);
        }


        public WeatherConfig GetConfig()
        {
            return config;
        }

        public void SetConfig(WeatherConfig config)
        {
            this.config = config;
        }

        public void StartCollect()
        {
            polling.Change(3000, 3000);

        }

        public void StopCollect()
        {
            polling.Change(Timeout.Infinite, Timeout.Infinite);
        }

        #endregion
    }
}
