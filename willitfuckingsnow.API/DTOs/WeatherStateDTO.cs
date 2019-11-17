using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace willitfuckingsnow.API.DTOs
{
    public class WeatherStateDTO
    {
        public float Temperature { get; set; }
        public string Weather { get; set; }
        public float SnowCover { get; set; }
    }
}
