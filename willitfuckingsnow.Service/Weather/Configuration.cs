using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

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
        public string API => "https://10.0.2.2:443/weather";
        public string Current => API + "/current";
        public string Forecast => API + "/forecast";
    }
}