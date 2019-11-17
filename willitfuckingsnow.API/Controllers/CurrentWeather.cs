using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using willitfuckingsnow.API.DTOs;

namespace willitfuckingsnow.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrentWeather : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CurrentWeather> _logger;

        public CurrentWeather(ILogger<CurrentWeather> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public WeatherStateDTO Get()
        {
            var rng = new Random();
            return new WeatherStateDTO
            {
                Weather = Summaries.ElementAt(rng.Next(0, Summaries.Length)),
                Temperature = rng.Next(-30, 60),
                SnowCover = rng.NextDouble() > 0.3
                    ? rng.Next(0, 100)
                    : 0
            };
        }
    }
}
