using willitfuckingsnow.Common.DTOs;
using willitfuckingsnow.Data.State;

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