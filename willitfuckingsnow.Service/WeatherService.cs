using Android.App;
using Android.Content;
using Android.OS;
using System;
using Optional;
using System.Linq;
using willitfuckingsnow.Data.State;
using System.Collections.Generic;
using willitfuckingsnow.Services.Weather;
using willitfuckingsnow.Common.DTOs;
using System.Net.Http;

namespace willitfuckingsnow.Services
{
    [Service]
    public class WeatherService : IntentService
    {
        Location location = new Location { Latitude = 20, Longitude = 50 };
        IWeatherRepository Repository { get; set; }

        public WeatherService()
        {

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            Repository = new WeatherRepository(
                new Configuration(),
                new System.Net.Http.HttpClient(handler));
        }
        protected override void OnHandleIntent(Intent intent)
        {
            var resultReciever = intent.GetParcelableExtra(WeatherServiceKeys.ResultReciever) as ResultReceiver;
            var command = intent.GetStringExtra(WeatherServiceKeys.Command);
            var forecasts = new List<WeatherState>();

            switch (command)
            {
                case WeatherServiceKeys.Current:
                    forecasts.Add(Current(location));
                    break;
                case WeatherServiceKeys.Forecast:
                    forecasts.AddRange(Forecast(location));
                    break;
                default:
                    break;
            }

            var bundle = new Bundle();
            bundle.PutParcelableArray(
                WeatherServiceKeys.Forecasts,
                forecasts.ToArray());

            resultReciever.Send(Result.Ok, bundle);
        }

        WeatherState Current(Location location)
            => Repository.Current(location).Result;

        IEnumerable<WeatherState> Forecast(Location location)
            => Repository.Forecast(location).Result;
    }

    public class WeatherServiceKeys
    {
        public const string Dates = "Dates";
        public const string Command = "Command";
        public const string Current = "Current";
        public const string Forecast = "Forecast";
        public const string ResultReciever = "Recievier";
        public const string Forecasts = "Forecasts";
    }
}
