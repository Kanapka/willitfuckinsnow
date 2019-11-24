using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using willitfuckingsnow.Data.Redux;

namespace willitfuckingsnow.Data.State
{
    public interface IApplicationState
    {
        WeatherState Today { get; set; }
        bool LoadingToday { get; set; }
        IEnumerable<WeatherState> Future { get; set; }
        bool LoadingFuture { get; set; }
    }
    public class ApplicationState : IApplicationState
    {
        public ApplicationState()
        {
            ;
        }
        public WeatherState Today { get; set; } = new WeatherState();
        public bool LoadingToday { get; set; } = false;
        public IEnumerable<WeatherState> Future { get; set; } = new List<WeatherState>();
        public bool LoadingFuture { get; set; } = false;

    }
}