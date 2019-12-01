﻿using System;
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
using willitfuckingsnow.Data.State;

namespace willitfuckingsnow.Data.Weather
{
    public interface IWeatherRepository
    {
        Task<WeatherState> GetCurrent();
        Task<WeatherState[]> GetForecast();
    }
}