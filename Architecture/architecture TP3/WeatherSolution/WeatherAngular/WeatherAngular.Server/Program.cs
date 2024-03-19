
using Weather.Business;
using Weather.Domain.Services;
using WeatherAngular.Server.Services;
using WeatherAngular.Server.ServicesImplementation;

namespace WeatherAngular.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // services for weather
            var repository = new QueuedRepository();
            builder.Services.AddSingleton<IQueryableQueuedRepository>(repository);
            builder.Services.AddSingleton<IQueuedRepository>(repository);
            builder.Services.AddSingleton<IWeatherDisplay, WeatherDisplay>();
            builder.Services.AddSingleton<IWeatherManager, WeatherManager>();
            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
