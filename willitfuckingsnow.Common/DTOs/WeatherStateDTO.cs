using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace willitfuckingsnow.Common.DTOs
{
    public class WeatherStateDTO
    {
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string AdditionalStatus { get; set; }
        public float Temperature { get; set; }
        public float SnowCover { get; set; }
    }
}
