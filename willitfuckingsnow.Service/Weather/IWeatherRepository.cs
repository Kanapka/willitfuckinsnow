using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Optional;
using willitfuckingsnow.Data.State;
using willitfuckingsnow.Common.DTOs;

namespace willitfuckingsnow.Services.Weather
{
    public interface IWeatherRepository
    {
        Task<WeatherState> Current(Location location);
        Task<WeatherState[]> Forecast(Location location);
    }
}