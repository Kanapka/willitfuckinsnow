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
using willitfuckingsnow.Common.DTOs;
using willitfuckingsnow.Data.State;
using willitfuckingsnow.Services;


namespace willitfuckingsnow.Services.Extensions
{
    public static class DtoExtensions
    {
        public static WeatherState ToWeatherState(this WeatherStateDTO dto)
            => new WeatherState
            {
                Location = dto.Location,
                Date = dto.Date,
                Status = dto.Status,
                AdditionalStatus = dto.AdditionalStatus,
                Temperature = dto.Temperature
            };
    }
}