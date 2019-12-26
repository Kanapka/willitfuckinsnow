using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using willitfuckingsnow.Common.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace willitfuckingsnow.API.Services
{
    public interface IForwarder
    {
        Task<External.ResponseDTO> GetCurrent(Location location);
        Task<External.ResponseDTO> GetForecast(Location location, int days);
    }
    public class Forwarder : IForwarder
    {
        string BaseUrl { get; set; }
        HttpClient Client { get; set; }
        IAuthorization Authorization { get; set; }
        string CurrentEndpoint => BaseUrl + "/current.json";
        string ForecastEndpoint => BaseUrl + "/forecast.json";

        public Forwarder(
            string baseUrl,
            HttpClient client,
            IAuthorization authorization)
        {
            BaseUrl = baseUrl;
            Client = client;
            Authorization = authorization;
        }

        public async Task<External.ResponseDTO> GetCurrent(Location location)
        {
            var uri = $"{CurrentEndpoint}?key={Authorization.Key}&q={location.Latitude},{location.Longitude}";
            return await Retrieve(uri);
        }

        public async Task<External.ResponseDTO> GetForecast(Location location, int days)
        {
            var uri = $"{ForecastEndpoint}?key={Authorization.Key}&q={location.Latitude},{location.Longitude}&days={days}";
            return await Retrieve(uri);
        }

        async Task<External.ResponseDTO> Retrieve(string uri)
        {
            var response = await Client.PostAsync(uri, null);
            var content = await response.Content.ReadAsStringAsync();
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            };
            var dto = JsonConvert.DeserializeObject<External.ResponseDTO>(content, settings);
            return dto;
        }

    }
}
