using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace willitfuckingsnow.Data.Weather
{
    class WeatherRepository : IWeatherRepository
    {
        public WeatherStateDTO Get()
        {
            return new WeatherStateDTO
            {
                Weather = "Fucked",
                Temperature = -4,
                SnowCover = 7
            };
        }
    }
}