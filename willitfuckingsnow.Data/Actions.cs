using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using willitfuckingsnow.Data.State;
using System.Threading.Tasks;
using System.Threading;

namespace willitfuckingsnow.Data
{
    public class Actions
    {
        public static Task<IApplicationState> SwitchToCurrent(IApplicationState state)
        {
            var rng = new Random();
            Thread.Sleep(2000);
            state.Today.Location = "Middle of fucking nowhere";
            state.Today.Date = DateTime.Now;
            state.Today.Status = "Rains like fuck";
            state.Today.AdditionalStatus = "And it ain't gonna stop today";
            state.Today.Temperature = (float)rng.NextDouble() * 20f;
            return Task.FromResult(state);
        }

        public static Task<IApplicationState> SwitchToForecast(IApplicationState state)
        {
            var rng = new Random();
            Thread.Sleep(2000);
            var future = new List<WeatherState>();
            for (int i = 0; i < 7; i++)
            {
                future.Add(new WeatherState()
                {
                    Location = "Middle of fucking nowhere",
                    Date = DateTime.Now,
                    Status = "Rains like fuck",
                    AdditionalStatus = "And it ain't gonna stop today",
                    Temperature = (float)rng.NextDouble() * 20f,
                });

            }
            state.Future = future;
            return Task.FromResult(state);
        }
    }
}