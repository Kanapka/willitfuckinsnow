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
using System.Net;
using System.Net.Http;
using willitfuckingsnow.Common.DTOs;
using Newtonsoft.Json;
using willitfuckingsnow.Services.Extensions;

namespace willitfuckingsnow.Services.Weather
{
    public class WeatherRepository : IWeatherRepository
    {
        IConfiguration Config { get; set; }
        HttpClient Client { get; set; }

        public WeatherRepository(IConfiguration config, HttpClient client)
        {
            Config = config;
            Client = client;
        }

        public async Task<WeatherState> Current(Location location)
        {
            var response1 = await Client.GetAsync("https://10.0.2.2/test");
            var content1 = await response1.Content.ReadAsStringAsync();
            var response = await Client.PostAsync(
                Config.Current,
                new StringContent(JsonConvert.SerializeObject(location), Encoding.UTF8, "application/json"));
            var content = await response.Content.ReadAsStringAsync();
            var current = JsonConvert
                .DeserializeObject<WeatherStateDTO>(content)
                .ToWeatherState();
            return current;

        }

        public async Task<WeatherState[]> Forecast(Location location)
        {
            var response = await Client.PostAsync(
                Config.Forecast,
                new StringContent(JsonConvert.SerializeObject(location), Encoding.UTF8, "application/json"));
            var content = await response.Content.ReadAsStringAsync();
            var forecast = JsonConvert
                .DeserializeObject<WeatherStateDTO[]>(content)
                .Select(x => x.ToWeatherState());
            return forecast.ToArray();
        }
    }
}