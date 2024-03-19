using Weather.Business;
using Weather.Domain.Services;
using WeatherWebServerSide.ServicesImplementation;
using Microsoft.AspNetCore.ResponseCompression;
using WeatherWebServerSide.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// signalR service
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
          new[] { "application/octet-stream" });
});

// services for weather
builder.Services.AddSingleton<IWeatherDisplay, WeatherDisplay>();
builder.Services.AddSingleton<IWeatherManager, WeatherManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseResponseCompression(); // signalR middleWare
app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();

app.MapFallbackToPage("/_Host");
app.MapHub<WeatherHub>("/weatherhub"); // hub endpoint 
app.Run();
