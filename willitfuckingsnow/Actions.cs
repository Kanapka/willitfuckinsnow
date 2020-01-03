using Android.Content;
using Android.OS;
using Nancy.TinyIoc;
using System.Collections.Generic;
using System.Linq;
using willitfuckingsnow.Data.Redux;
using willitfuckingsnow.Data.State;
using willitfuckingsnow.Services;

namespace willitfuckingsnow
{
    public class CurrentWeather : ActionPayload
    {
        public WeatherState Weather { get; set; }
    }

    public class WeatherCollection : ActionPayload
    {
        public IEnumerable<WeatherState> States { get; set; }
    }

    public class Actions
    {
        public static IApplicationState FinalizeUpdateCurrent(IApplicationState state, CurrentWeather current)
        {
            state.Today = current.Weather;
            state.Busy.Today = false;
            return state;
        }

        public static IApplicationState FinalizeUpdateForecast(IApplicationState state, WeatherCollection collection)
        {
            state.Future = collection.States;
            state.Busy.Future = false;
            return state;
        }

        public static IApplicationState InitializeUpdateCurrent(IApplicationState state)
        {
            state.Busy.Today = true;
            var intent = new Intent(Android.App.Application.Context, typeof(WeatherService));

            intent.PutExtra(
                WeatherServiceKeys.Command,
                WeatherServiceKeys.Current);
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

            intent.PutExtra(
                WeatherServiceKeys.Command,
                WeatherServiceKeys.Forecast);
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
            var results = resultData.GetParcelableArray(WeatherServiceKeys.Forecast).Cast<WeatherState>();
            var store = TinyIoCContainer.Current.Resolve<IReduxStore<IApplicationState>>();
            var payload = new CurrentWeather();
            payload.Weather = results.First();
            store.Commit(Actions.FinalizeUpdateCurrent, payload);
            base.OnReceiveResult(resultCode, resultData);
        }
    }

    public class MultipleDaysResultReciever : ResultReceiver
    {
        public MultipleDaysResultReciever() : base(new Handler()) { }
        protected override void OnReceiveResult(int resultCode, Bundle resultData)
        {
            var results = resultData.GetParcelableArray(WeatherServiceKeys.Forecast).Cast<WeatherState>();
            var store = TinyIoCContainer.Current.Resolve<IReduxStore<IApplicationState>>();
            var payload = new WeatherCollection();
            payload.States = results;
            store.Commit(Actions.FinalizeUpdateForecast, payload);
            base.OnReceiveResult(resultCode, resultData);
        }
    }
}