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
using willitfuckingsnow.Data.State;

namespace willitfuckingsnow.Data.Weather
{
    public class WeatherRepository : IWeatherRepository
    {
        IConfiguration Config { get; set; }

        public WeatherRepository(IConfiguration config)
        {
            Config = config;
        }

        public Task<WeatherState> Get(DateTime date)
        {
            var rng = new Random();
            return Task.FromResult(new WeatherState
            {
                Date = DateTime.Now,
                Location = "SDFSDG",
                Status = "Fucked",
                Temperature = rng.Next(-10, 50),
                SnowCover = rng.NextDouble() > 0.3
                        ? rng.Next(0, 100)
                        : 0
            });
        }

        public Task<WeatherState[]> Get(IEnumerable<DateTime> dates)
        {
            var rng = new Random();
            string[] Summaries = new[]
            {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };
            return Task.FromResult(new WeatherState[]
            {
                new WeatherState
                {
                    Date = DateTime.Now.AddDays(0),
                    Status = Summaries.ElementAt(rng.Next(0, Summaries.Length)),
                    Temperature = rng.Next(-30, 60),
                    SnowCover = rng.NextDouble() > 0.3
                        ? rng.Next(0, 100)
                        : 0
                },
                new WeatherState
                {
                    Date = DateTime.Now.AddDays(1),
                    Status = Summaries.ElementAt(rng.Next(0, Summaries.Length)),
                    Temperature = rng.Next(-30, 60),
                    SnowCover = rng.NextDouble() > 0.3
                        ? rng.Next(0, 100)
                        : 0
                },
                new WeatherState
                {
                    Date = DateTime.Now.AddDays(2),
                    Status = Summaries.ElementAt(rng.Next(0, Summaries.Length)),
                    Temperature = rng.Next(-30, 60),
                    SnowCover = rng.NextDouble() > 0.3
                        ? rng.Next(0, 100)
                        : 0
                },
                new WeatherState
                {
                    Date = DateTime.Now.AddDays(3),
                    Status = Summaries.ElementAt(rng.Next(0, Summaries.Length)),
                    Temperature = rng.Next(-30, 60),
                    SnowCover = rng.NextDouble() > 0.3
                        ? rng.Next(0, 100)
                        : 0
                },
                new WeatherState
                {
                    Date = DateTime.Now.AddDays(4),
                    Status = Summaries.ElementAt(rng.Next(0, Summaries.Length)),
                    Temperature = rng.Next(-30, 60),
                    SnowCover = rng.NextDouble() > 0.3
                        ? rng.Next(0, 100)
                        : 0
                },
                new WeatherState
                {
                    Date = DateTime.Now.AddDays(5),
                    Status = Summaries.ElementAt(rng.Next(0, Summaries.Length)),
                    Temperature = rng.Next(-30, 60),
                    SnowCover = rng.NextDouble() > 0.3
                        ? rng.Next(0, 100)
                        : 0
                },
                new WeatherState
                {
                    Date = DateTime.Now.AddDays(6),
                    Status = Summaries.ElementAt(rng.Next(0, Summaries.Length)),
                    Temperature = rng.Next(-30, 60),
                    SnowCover = rng.NextDouble() > 0.3
                        ? rng.Next(0, 100)
                        : 0
                }
            });
        }
    }
}