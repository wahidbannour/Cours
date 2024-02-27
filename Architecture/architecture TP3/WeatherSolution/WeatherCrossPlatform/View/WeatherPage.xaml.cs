using Weather.Domain.Services;
using WeatherCrossPlatform.ViewModel;

namespace WeatherCrossPlatform.View;

public partial class WeahterPage : ContentPage, IQueryAttributable
{
	public WeahterPage()
	{
        InitializeComponent();
    }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        BindingContext =  query["vm"] as WeatherManagerVM;
    }

}