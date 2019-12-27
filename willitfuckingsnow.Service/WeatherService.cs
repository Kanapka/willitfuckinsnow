using Android.App;
using Android.Content;
using Android.OS;
using System;
using Optional;
using System.Linq;
using willitfuckingsnow.Data;
using willitfuckingsnow.Data.Weather;
using willitfuckingsnow.Data.State;
using System.Collections.Generic;

namespace willitfuckingsnow.Services
{
    [Service]
    public class WeatherService : IntentService
    {
        const int NOTIFICATION_ID = 39058624;
        IWeatherRepository Repository { get; set; }

        public WeatherService()
        {
            Repository = new WeatherRepository(new Configuration());
        }
        protected override void OnHandleIntent(Intent intent)
        {

            var resultReciever1 = intent.GetParcelableExtra(WeatherServiceKeys.ResultReciever);
            var resultReciever = intent.GetParcelableExtra(WeatherServiceKeys.ResultReciever) as ResultReceiver;

            var dates = Dates(intent)
                .Select(x => DateTime.TryParse(x, out var date)
                        ? Option.Some(date)
                        : Option.None<DateTime>())
                .Where(f => f.HasValue)
                .Select(f => f.ValueOr(() => DateTime.MinValue));

            var forecasts = Forecast(dates);

            var bundle = new Bundle();
            bundle.PutParcelableArray(
                WeatherServiceKeys.Forecasts,
                forecasts.ToArray());

            resultReciever.Send(Result.Ok, bundle);

        }

        string[] Dates(Intent intent)
            => intent.Extras.GetStringArray(WeatherServiceKeys.Dates) ?? new string[] { };

        IEnumerable<WeatherState> Forecast(IEnumerable<DateTime> dates)
            => Repository.Forecast(dates).Result;

        WeatherState Forecast(DateTime date)
            => Repository.Current(date).Result;
    }

    public class WeatherServiceKeys
    {
        public static string Dates => "Dates";
        public static string ResultReciever => "Recievier";
        public static string Forecasts => "Forecasts";
    }
}
