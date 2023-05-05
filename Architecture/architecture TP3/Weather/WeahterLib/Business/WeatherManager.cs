using SharedWeather.Entities;
using SharedWeather.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SharedWeather.Business
{
    public class WeatherManager : IWeatherOut
    {

        IWeatherIn _weatherIn;
        WeatherConfig config;
        WeatherInfo weatherInfo;

        System.Threading.Timer timerPrecepitation;
        System.Threading.Timer timerWind;
        System.Threading.Timer timerPression;
        System.Threading.Timer timerTemperature;
        Random random;


        public WeatherManager(IWeatherIn weatherIn)
        {
            _weatherIn = weatherIn;
            random = new Random(5);
            weatherInfo = new WeatherInfo();
        }


        public void StartCollect()
        {
            weatherInfo = new WeatherInfo();
            if (config.HasPrecipitation)
            {
                timerPrecepitation = new System.Threading.Timer(NewValuePrecipitation);
                timerPrecepitation.Change(5000, 5000);
            }
            if (config.HasWind)
            {
                timerWind = new System.Threading.Timer(NewValueWind);
                timerWind.Change(3000, 3000);
            }
            if (config.HasTemperature)
            {
                timerTemperature = new System.Threading.Timer(NewValueTemperature);
                timerTemperature.Change(2000, 2000);
            }
            if (config.HasPression)
            {
                timerPression = new System.Threading.Timer(NewValuePression);
                timerPression.Change(10000, 10000);
            }
        }

        private void NewValuePression(object state)
        {
            weatherInfo.Pression = random.Next(50);
            //_weatherIn.WriteWeatherValue("Pression",weatherInfo.Pression.ToString());
            _weatherIn.WriteWeather(weatherInfo);
        }

        private void NewValueTemperature(object state)
        {
            weatherInfo.Temperature = random.Next(30);
            _weatherIn.WriteWeatherValue("Temperature", weatherInfo.Temperature.ToString());
            _weatherIn.WriteWeather(weatherInfo);
        }

        private void NewValueWind(object state)
        {
            weatherInfo.Wind = random.Next(10);
            _weatherIn.WriteWeatherValue("Wind", weatherInfo.Wind.ToString());
            _weatherIn.WriteWeather(weatherInfo);
        }

        private void NewValuePrecipitation(object state)
        {
            weatherInfo.Precipitation = random.Next(100);
            _weatherIn.WriteWeatherValue( "Precipitation", weatherInfo.Precipitation.ToString());
            _weatherIn.WriteWeather(weatherInfo);
        }

        public WeatherConfig GetWeatherInfo()
        {
            return this.config;
        }

        public void SetWeatherInfo(WeatherConfig config)
        {
            this.config = config;
        }

        public void StopCollect()
        {
            timerPrecepitation?.Dispose();
            timerPression?.Dispose();
            timerWind?.Dispose();
            timerPression?.Dispose();
        }
    }
}
