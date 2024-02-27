using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SharedWeather;
using SharedWeather.Business;
using SharedWeather.Entities;
using SharedWeather.Interfaces;

namespace WPFweather
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , IWeatherIn
    {
        IWeatherOut _weather;

        public MainWindow()
        {
            InitializeComponent();
            _weather = new WeatherManager(this);
        }

        public void WriteWeather(WeatherInfo weatherInfo)
        {
            Dispatcher.Invoke(() =>
            Resultat.Text += "Température = " + weatherInfo.Temperature + Environment.NewLine +
                "Vent = " + weatherInfo.Wind + Environment.NewLine +
                "Précipitation= " + weatherInfo.Precipitation+ Environment.NewLine +
                "Pression = " + weatherInfo.Pression);

        }

        public void WriteWeatherValue(string valueType, string value)
        {
           // Dispatcher.Invoke(()=> 
           //         Resultat.Text += valueType + " : " + value + "   @ " + DateTime.Now +  Environment.NewLine);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _weather.SetWeatherInfo(new SharedWeather.Entities.WeatherConfig
                                        { HasPrecipitation = (bool)HasPrecipitation.IsChecked,
                                          HasWind = (bool) HasWind.IsChecked,
                                          HasPression = (bool) HasPression.IsChecked,
                                          HasTemperature = (bool) HasTemperature.IsChecked,
                                         });
            _weather.StartCollect();
        }
    }
}
