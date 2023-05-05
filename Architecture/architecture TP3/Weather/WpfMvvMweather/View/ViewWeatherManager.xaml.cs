using SharedWeather.Business;
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
using System.Windows.Shapes;
using WpfMvvMweather.ViewModel;

namespace WpfMvvMweather.View
{
    /// <summary>
    /// Interaction logic for ViewWeatherManager.xaml
    /// </summary>
    public partial class ViewWeatherManager : Window
    {
        public ViewWeatherManager()
        {
            InitializeComponent();
            VMAffichageWeather vMAffichageWeather = new VMAffichageWeather();
            base.DataContext = new ViewModel.VMWeather(new WeatherManager(vMAffichageWeather), vMAffichageWeather);
        }
    }
}
