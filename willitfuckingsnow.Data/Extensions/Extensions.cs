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
using willitfuckingsnow.Data.State;
using willitfuckingsnow.Data.Weather;
using willitfuckingsnow.Common.DTOs;

namespace willitfuckingsnow.Data.Extensions
{
    public static class Extensions
    {
        public static WeatherState ToWeatherState(this WeatherStateDTO stateDTO)
        {
            return new WeatherState
            {
                Location = stateDTO.Location,
                Date = stateDTO.Date,
                Status = stateDTO.Status,
                AdditionalStatus = stateDTO.Status,
                Temperature = stateDTO.Temperature,
                SnowCover = stateDTO.SnowCover
            };
        }
    }
}