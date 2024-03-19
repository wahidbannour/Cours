using Weather.Domain.Entities;

namespace WeatherAngular.Server.Services
{
    public interface IQueryableQueuedRepository
    {
        IList<WeatherInfo> GetQueuedWeatherInfos();
        void ClearQueue();
    }
    public interface IQueuedRepository
    {
        void PutQueuedWeatherInfo(WeatherInfo info);

    }
}
