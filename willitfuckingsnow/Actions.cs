using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using willitfuckingsnow.Data.State;
using System.Threading.Tasks;
using System.Threading;
using Android.Content;
using willitfuckingsnow.Services;
using willitfuckingsnow.Data;
using Android.OS;
using willitfuckingsnow.Data.Redux;
using TinyIoC;

namespace willitfuckingsnow
{
    public class CurrentWeather : ActionPayload
    {
        public WeatherState weather { get; set; }
    }

    public class WeatherCollection : ActionPayload
    {
        public IEnumerable<WeatherState> states { get; set; }
    }

    public class Actions
    {
        public static IApplicationState FinalizeUpdateCurrent(IApplicationState state, CurrentWeather current)
        {
            state.Today = current.weather;
            state.Busy.Today = false;
            return state;
        }

        public static IApplicationState FinalizeUpdateForecast(IApplicationState state, WeatherCollection collection)
        {
            state.Future = collection.states;
            state.Busy.Future = false;
            return state;
        }

        public static IApplicationState InitializeUpdateCurrent(IApplicationState state)
        {
            state.Busy.Today = true;
            var intent = new Intent(Android.App.Application.Context, typeof(WeatherService));
            var dates = new string[]
            {
                DateTime.Now.ToString()
            };

            intent.PutStringArrayListExtra(
                WeatherServiceKeys.Dates,
                dates.ToList());
            intent.PutExtra(
                WeatherServiceKeys.ResultReciever,
                new SingleDayResultReciever());
            Android.App.Application.Context.ApplicationContext.StartService(intent);

            return state;
        }

        public static IApplicationState InitializeUpdateForecast(IApplicationState state)
        {
            state.Busy.Future = true;
            var intent = new Intent(Android.App.Application.Context, typeof(WeatherService));
            var dates = new DateTime[]
            {
                DateTime.Now,
                DateTime.Now.AddDays(1),
                DateTime.Now.AddDays(2),
                DateTime.Now.AddDays(3),
                DateTime.Now.AddDays(4)
            }
            .Select(d => d.ToString());

            intent.PutStringArrayListExtra(
                WeatherServiceKeys.Dates,
                dates.ToList());
            intent.PutExtra(
                WeatherServiceKeys.ResultReciever,
                new MultipleDaysResultReciever());
            Android.App.Application.Context.ApplicationContext.StartService(intent);

            return state;
        }
    }
    public class SingleDayResultReciever : ResultReceiver
    {
        public SingleDayResultReciever() : base(new Handler()) { }

        protected override void OnReceiveResult(int resultCode, Bundle resultData)
        {
            var results = resultData.GetParcelableArray(WeatherServiceKeys.Forecasts).Cast<WeatherState>();
            var store = TinyIoCContainer.Current.Resolve<IReduxStore<IApplicationState>>();
            var payload = new CurrentWeather();
            payload.weather = results.First();
            store.Commit(Actions.FinalizeUpdateCurrent, payload);
            base.OnReceiveResult(resultCode, resultData);
        }
    }

    public class MultipleDaysResultReciever : ResultReceiver
    {
        public MultipleDaysResultReciever() : base(new Handler()) { }
        protected override void OnReceiveResult(int resultCode, Bundle resultData)
        {
            var results = resultData.GetParcelableArray(WeatherServiceKeys.Forecasts).Cast<WeatherState>();
            var store = TinyIoCContainer.Current.Resolve<IReduxStore<IApplicationState>>();
            var payload = new WeatherCollection();
            payload.states = results;
            store.Commit(Actions.FinalizeUpdateForecast, payload);
            base.OnReceiveResult(resultCode, resultData);
        }
    }
}