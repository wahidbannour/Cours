using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.Entities;
using Weather.Domain.Services;
using WeatherWebServerSide.Hubs;

namespace WeatherWebServerSide.ServicesImplementation
{
    
    public class WeatherDisplay :  IWeatherDisplay
    {
        private readonly IHubContext<WeatherHub> hubContext;

        public WeatherDisplay(IHubContext<WeatherHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public void Display(WeatherInfo info)
        {
            hubContext.Clients.All.SendAsync("ReceiveWeatherInfo",info);
        }

        public void Display(string log)
        {
            hubContext.Clients.All.SendAsync("ReceiveLog", log);
        }
    }
}
