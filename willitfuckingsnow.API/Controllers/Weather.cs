using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using willitfuckingsnow.Common.DTOs;
using willitfuckingsnow.API.Services;
using willitfuckingsnow.API.Extensions;

namespace willitfuckingsnow.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Weather : ControllerBase
    {
        ILogger<Weather> _logger;
        IExternalAPI ExternalApi;

        public Weather(
            ILogger<Weather> logger,
            IExternalAPI externalApi)
        {
            _logger = logger;
            ExternalApi = externalApi;
        }

        [HttpPost("current")]
        public WeatherStateDTO Get([FromBody] Location location)
        {
            var response = ExternalApi.GetCurrent(location).Result;
            return response.GetSingleDay();
        }

        [HttpPost("forecast")]
        public IEnumerable<WeatherStateDTO> Forecast([FromBody] Location location)
        {
            var response = ExternalApi.GetForecast(location, 7).Result;
            return response.GetForecast();
        }
    }
}

