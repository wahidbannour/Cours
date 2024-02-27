using Weather.Domain.Services;
using WeatherCrossPlatform.ViewModel;

namespace WeatherCrossPlatform
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void NavBtn_Clicked(object sender, EventArgs e)
        {
            var service = Handler!.MauiContext!.Services.GetService(typeof(WeatherManagerVM));
            
            var navigationParameter = new ShellNavigationQueryParameters
                        {
                            { "vm", service!}
                        };
            await Shell.Current.GoToAsync("//WeatherPage",navigationParameter);
        }
    }   

}
