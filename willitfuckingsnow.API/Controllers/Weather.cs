using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using willitfuckingsnow.Common.DTOs;

namespace willitfuckingsnow.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Weather : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<Weather> _logger;

        public Weather(ILogger<Weather> logger)
        {
            _logger = logger;
        }

        [HttpGet("current")]
        public WeatherStateDTO Get([FromBody] LocationDTO location)
        {
            var rng = new Random();
            return new WeatherStateDTO
            {
                Location = "Hell itself",
                Date = DateTime.Now,
                Status = Summaries.ElementAt(rng.Next(0, Summaries.Length)),
                AdditionalStatus = "Gonna be hellish",
                Temperature = rng.Next(-30, 60),
                SnowCover = rng.NextDouble() > 0.3
                    ? rng.Next(0, 100)
                    : 0
            };
        }
        public WeatherStateDTO[] Forecast([FromBody] LocationDTO location)
        {
            var rng = new Random();
            return new WeatherStateDTO[]
            {
                new WeatherStateDTO
                {
                    Location = "Hell itself",
                    Date = DateTime.Now.AddDays(0),
                    Status = Summaries.ElementAt(rng.Next(0, Summaries.Length)),
                    AdditionalStatus = "Gonna be hellish",
                    Temperature = rng.Next(-30, 60),
                    SnowCover = rng.NextDouble() > 0.3
                        ? rng.Next(0, 100)
                        : 0
                },
                new WeatherStateDTO
                {
                    Location = "Hell itself",
                    Date = DateTime.Now.AddDays(1),
                    Status = Summaries.ElementAt(rng.Next(0, Summaries.Length)),
                    AdditionalStatus = "Gonna be hellish",
                    Temperature = rng.Next(-30, 60),
                    SnowCover = rng.NextDouble() > 0.3
                        ? rng.Next(0, 100)
                        : 0
                },
                new WeatherStateDTO
                {
                    Location = "Hell itself",
                    Date = DateTime.Now.AddDays(2),
                    Status = Summaries.ElementAt(rng.Next(0, Summaries.Length)),
                    AdditionalStatus = "Gonna be hellish",
                    Temperature = rng.Next(-30, 60),
                    SnowCover = rng.NextDouble() > 0.3
                        ? rng.Next(0, 100)
                        : 0
                },
                new WeatherStateDTO
                {
                    Location = "Hell itself",
                    Date = DateTime.Now.AddDays(3),
                    Status = Summaries.ElementAt(rng.Next(0, Summaries.Length)),
                    AdditionalStatus = "Gonna be hellish",
                    Temperature = rng.Next(-30, 60),
                    SnowCover = rng.NextDouble() > 0.3
                        ? rng.Next(0, 100)
                        : 0
                },
                new WeatherStateDTO
                {
                    Location = "Hell itself",
                    Date = DateTime.Now.AddDays(4),
                    Status = Summaries.ElementAt(rng.Next(0, Summaries.Length)),
                    AdditionalStatus = "Gonna be hellish",
                    Temperature = rng.Next(-30, 60),
                    SnowCover = rng.NextDouble() > 0.3
                        ? rng.Next(0, 100)
                        : 0
                },
                new WeatherStateDTO
                {
                    Location = "Hell itself",
                    Date = DateTime.Now.AddDays(5),
                    Status = Summaries.ElementAt(rng.Next(0, Summaries.Length)),
                    AdditionalStatus = "Gonna be hellish",
                    Temperature = rng.Next(-30, 60),
                    SnowCover = rng.NextDouble() > 0.3
                        ? rng.Next(0, 100)
                        : 0
                },
                new WeatherStateDTO
                {
                    Location = "Hell itself",
                    Date = DateTime.Now.AddDays(6),
                    Status = Summaries.ElementAt(rng.Next(0, Summaries.Length)),
                    AdditionalStatus = "Gonna be hellish",
                    Temperature = rng.Next(-30, 60),
                    SnowCover = rng.NextDouble() > 0.3
                        ? rng.Next(0, 100)
                        : 0
                }
            };
        }
    }
}
