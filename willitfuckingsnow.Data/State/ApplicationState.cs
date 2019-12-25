using Android.Support.V4.OS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using willitfuckingsnow.Data.Redux;
using willitfuckingsnow.Data.Weather;

namespace willitfuckingsnow.Data.State
{
    public interface IApplicationState
    {
        WeatherState Today { get; set; }
        IEnumerable<WeatherState> Future { get; set; }
        BusyState Busy { get; set; }
        IWeatherRepository Repository { get; set; }
    }
    public class ApplicationState : IApplicationState
    {
        public ApplicationState(IWeatherRepository repository)
        {
            Repository = repository;
        }
        public WeatherState Today { get; set; } = new WeatherState();
        public IEnumerable<WeatherState> Future { get; set; } = new List<WeatherState>();
        public BusyState Busy { get; set; } = new BusyState();
        public IWeatherRepository Repository { get; set; }

    }
    public class BusyState
    {
        public bool Today { get; set; } = false;
        public bool Future { get; set; } = false;
    }
}