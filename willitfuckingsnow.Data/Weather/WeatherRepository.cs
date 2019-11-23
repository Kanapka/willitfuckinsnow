using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace willitfuckingsnow.Data.Weather
{
    public class WeatherRepository : IWeatherRepository
    {
        public Task<WeatherStateDTO> Get()
        {
            Thread.Sleep(1500);
            return Task.FromResult(new WeatherStateDTO
            {
                Weather = "Fucked",
                Temperature = -4,
                SnowCover = 7
            });
        }
    }
}