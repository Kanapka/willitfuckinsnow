using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using willitfuckingsnow.Common.DTOs;

namespace willitfuckingsnow.API.Extensions
{
    public static class DtoExtensions
    {
        public static WeatherStateDTO GetSingleDay(this External.ResponseDTO response)
            => new WeatherStateDTO
            {
                Location = response.Location.Name,
                Date = DateTime.Parse(response.Current.LastUpdated),
                Status = response.Current.Condition.Text,
                AdditionalStatus = "Gonna be hellish",
                Temperature = response.Current.TempC
            };

        public static IEnumerable<WeatherStateDTO> GetForecast(this External.ResponseDTO response)
        {
            return response.Forecast.Forecastday.Select(x =>
            new WeatherStateDTO
            {
                Location = response.Location.Name,
                Date = DateTime.Parse(x.Date),
                Status = x.Day.Condition.Text,
                AdditionalStatus = "You're fucked",
                Temperature = x.Day.AvgtempC,

            });
        }
    }
}
