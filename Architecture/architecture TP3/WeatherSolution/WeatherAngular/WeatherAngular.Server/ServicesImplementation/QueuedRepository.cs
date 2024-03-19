using System.Collections.Concurrent;
using Weather.Domain.Entities;
using WeatherAngular.Server.Services;

namespace WeatherAngular.Server.ServicesImplementation
{
    public class QueuedRepository : IQueuedRepository, IQueryableQueuedRepository
    {
        readonly ConcurrentQueue<WeatherInfo> _queue = new();

        public void ClearQueue()
        {
            _queue.Clear();
        }

        public IList<WeatherInfo> GetQueuedWeatherInfos()
        {
            List<WeatherInfo> list = [];

            if (_queue.IsEmpty) return list;
            var maxList = _queue.Count;
            for (int i = 0; i < maxList ; i++)
            {
                WeatherInfo? weatherInfo = null;
                if(_queue.TryDequeue(out weatherInfo) && weatherInfo != null)
                    list.Add(weatherInfo);
            }
            return list;
        }

        public void PutQueuedWeatherInfo(WeatherInfo info)
        {   // create copy and enqueue
            WeatherInfo winfo = new WeatherInfo();
            winfo.Pression = info.Pression;
            winfo.Precipitation = info.Precipitation;
            winfo.Temperature = info.Temperature;
            winfo.Wind = info.Wind;
            _queue.Enqueue(winfo);
        }
    }
}
