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
        public static Task<IApplicationState> SwitchToCurrent(IApplicationState state)
        {
            //state.Today = state.Repository.Get(DateTime.Now).Result;
            return Task.FromResult(state);
        }

        public static Task<IApplicationState> SwitchToForecast(IApplicationState state)
        {
            //state.Future = state.Repository.Get(new DateTime[] { DateTime.Now, DateTime.Now.AddDays(1) }).Result;
            return Task.FromResult(state);
        }

        public static IApplicationState UpdateCurrent(IApplicationState state, CurrentWeather current)
        {
            state.Today = current.weather;
            return state;
        }

        public static IApplicationState UpdateForecast(IApplicationState state, WeatherCollection collection)
        {
            state.Future = collection.states;
            return state;
        }
    }

    //public class SingleDayResultReciever : ResultReceiver
    //{
    //    public SingleDayResultReciever() : base(null) { }

    //    protected override void OnReceiveResult(int resultCode, Bundle resultData)
    //    {

    //        base.OnReceiveResult(resultCode, resultData);
    //    }
    //}
}