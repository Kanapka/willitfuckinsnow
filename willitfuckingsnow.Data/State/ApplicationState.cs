using System.Collections.Generic;

namespace willitfuckingsnow.Data.State
{
    public interface IApplicationState
    {
        WeatherState Today { get; set; }
        IEnumerable<WeatherState> Future { get; set; }
        BusyState Busy { get; set; }
    }
    public class ApplicationState : IApplicationState
    {
        public WeatherState Today { get; set; } = new WeatherState();
        public IEnumerable<WeatherState> Future { get; set; } = new List<WeatherState>();
        public BusyState Busy { get; set; } = new BusyState();

    }
    public class BusyState
    {
        public bool Today { get; set; } = false;
        public bool Future { get; set; } = false;
    }
}