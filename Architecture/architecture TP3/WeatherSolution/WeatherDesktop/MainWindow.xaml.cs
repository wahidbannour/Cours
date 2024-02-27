using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Weather.Business;
using Weather.Domain.Entities;
using Weather.Domain.Services;

namespace WeatherDesktop
{



    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWeatherDisplay
    {

        WeatherConfig config;
        WeatherInfo info;
        IWeatherManager weather;


        public MainWindow()
        {
            InitializeComponent();
            config = new WeatherConfig();
            weather = new WeatherManager(this);
        }

        private void stopB_Click(object sender, RoutedEventArgs e)
        {
            weather.StopCollect();
        }

        private void StartB_Click(object sender, RoutedEventArgs e)
        {
            if (HasWind.IsChecked == true)
                config.HasWind = true;
            else
                config.HasWind = false;
            
            if (HasPrecipitation.IsChecked == true)
                config.HasPrecipitation = true;
            else
                config.HasPrecipitation = false;
            
            if (HasPression.IsChecked == true)
                config.HasPression = true;
            else
                config.HasPression = false;

            if (HasTemperature.IsChecked == true)
                config.HasTemperature = true;
            else
                config.HasTemperature = false;
            weather.SetConfig(config);
            Resultat.Text = "";
            weather.StartCollect();
        }

        public void Display(WeatherInfo info)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (config.HasTemperature)
                {
                    Resultat.Text += "Température = " + info.Temperature.ToString() + Environment.NewLine;
                }
                if (config.HasPression)
                {
                    Resultat.Text += "Pression = " + info.Pression.ToString() + Environment.NewLine;
                }
                if (config.HasWind)
                {
                    Resultat.Text += "Wind = " + info.Wind.ToString() + Environment.NewLine;
                }
                if (config.HasPrecipitation)
                {
                    Resultat.Text += "Precipitation = " + info.Precipitation.ToString() + Environment.NewLine;
                }
            });
            

        }

        public void Display(string log)
        {
            throw new NotImplementedException();
        }
    }
}