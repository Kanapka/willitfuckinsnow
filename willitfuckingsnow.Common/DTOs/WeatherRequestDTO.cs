using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace willitfuckingsnow.Common.DTOs
{
    public class WeatherRequestDTO
    {
        public Location Location { get; set; }
        public DateTime[] Dates { get; set; }
    }
    public class Location
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}
