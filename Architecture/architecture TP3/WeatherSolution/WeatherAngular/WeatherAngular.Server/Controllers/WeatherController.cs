using Microsoft.AspNetCore.Mvc;
using Weather.Domain.Entities;
using Weather.Domain.Services;
using Weather.Business;
using WeatherAngular.Server.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherAngular.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        IWeatherManager _weatherManager;
        IQueryableQueuedRepository _repository;

        public WeatherController(IWeatherManager weatherManager, IQueryableQueuedRepository repository)
        {
            _weatherManager = weatherManager;
            _repository = repository;
        }

        [HttpGet("GetInfo")]
        public IEnumerable<WeatherInfo> GetWeatherInfo()
        {
            return _repository.GetQueuedWeatherInfos();
        }

        [HttpGet ("Start")]
        public void StartWeatherCollect()
        {
            _weatherManager.StartCollect();
        }

        [HttpGet("Stop")]
        public void StopWeatherCollect()
        {
            _weatherManager.StopCollect();
            _repository.ClearQueue();
        }


        [HttpPost("SetConfig")]
        public void SetConfig([FromBody] WeatherConfig config)
        {
            _weatherManager.SetConfig(config);
        }

        [HttpGet("GetConfig")]
        public WeatherConfig GetConfig()
        {
            return _weatherManager.GetConfig();
        }
    }
}
