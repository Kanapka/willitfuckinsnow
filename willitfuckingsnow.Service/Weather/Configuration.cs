namespace willitfuckingsnow.Services.Weather
{
    public interface IConfiguration
    {
        string API { get; }
        string Current { get; }
        string Forecast { get; }
    }
    public class Configuration : IConfiguration
    {
        public string API => "https://10.0.2.2/weather";
        public string Current => API + "/current";
        public string Forecast => API + "/forecast";
    }
}