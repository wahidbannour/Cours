using Weather.Domain.Entities;
using Weather.Domain.Services;
using WeatherAngular.Server.Services;

namespace WeatherAngular.Server.ServicesImplementation
{
    public class WeatherDisplay : IWeatherDisplay
    {
        private IQueuedRepository _repository;
        
        public WeatherDisplay(IQueuedRepository repository) 
        { 
            _repository = repository;
        } 

        public void Display(WeatherInfo info)
        {
            _repository.PutQueuedWeatherInfo(info);
        }

        public void Display(string log)
        {
            throw new NotImplementedException();
        }
    }
}
