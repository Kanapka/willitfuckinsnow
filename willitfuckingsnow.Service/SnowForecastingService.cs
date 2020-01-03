using Android.Content;
using Nancy.TinyIoc;
using System;
using System.Linq;
using willitfuckingsnow.Services.Weather;
using willitfuckingsnow.Common.DTOs;

namespace willitfuckingsnow.Services
{
    [BroadcastReceiver]
    public class SnowForecastingService : BroadcastReceiver
    {
        public SnowForecastingService()
        {
            Repository = TinyIoCContainer.Current.Resolve<IWeatherRepository>();
        }
        IWeatherRepository Repository { get; set; }
        public override void OnReceive(Context context, Intent intent)
        {
            Location location = new Location { Latitude = 50, Longitude = 20 };
            var forecast = Repository.Forecast(location).Result;
            var temperature = forecast
                .FirstOrDefault()?
                .Temperature ?? -245624;
            var status = temperature > 0
                ? "It will be somewhat warm"
                : "Will be cold as fuck";
            var notificationText = $"Tomorrow: {Environment.NewLine} {temperature} C {Environment.NewLine} {status}";
            UserBotheringService.SetNotification(context, notificationText);
        }
    }
}