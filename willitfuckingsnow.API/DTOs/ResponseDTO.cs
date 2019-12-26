using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace willitfuckingsnow.API.External
{
    public class ResponseDTO
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
        public Forecast Forecast { get; set; }
        public Alert Alert { get; set; }

    }
    public class Location
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
        public string TzId { get; set; }
        public int LocaltimeEpoch { get; set; }
        public string Localtime { get; set; }
    }

    public class Current
    {
        public int LastUpdatedEpoch { get; set; }
        public string LastUpdated { get; set; }
        public float TempC { get; set; }
        public float TempF { get; set; }
        public int IsDay { get; set; }
        public Condition Condition { get; set; }
        public float WindMph { get; set; }
        public float WindKph { get; set; }
        public int WindDegree { get; set; }
        public string WindDir { get; set; }
        public float PressureMb { get; set; }
        public float PressureIn { get; set; }
        public float PrecipMm { get; set; }
        public float PrecipIn { get; set; }
        public int Humidity { get; set; }
        public int Cloud { get; set; }
        public float FeelslikeC { get; set; }
        public float FeelslikeF { get; set; }
        public float VisKm { get; set; }
        public float VisMiles { get; set; }
        public float Uv { get; set; }
        public float GustMph { get; set; }
        public float GustKph { get; set; }
    }

    public class Condition
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public int Code { get; set; }
    }

    public class Forecast
    {
        public Forecastday[] Forecastday { get; set; }
    }

    public class Forecastday
    {
        public string Date { get; set; }
        public int DateEpoch { get; set; }
        public Day Day { get; set; }
        public Astro Astro { get; set; }
    }

    public class Day
    {
        public float MaxtempC { get; set; }
        public float MaxtempF { get; set; }
        public float MintempC { get; set; }
        public float MintempF { get; set; }
        public float AvgtempC { get; set; }
        public float AvgtempF { get; set; }
        public float MaxwindMph { get; set; }
        public float MaxwindKph { get; set; }
        public float TotalprecipMm { get; set; }
        public float TotalprecipIn { get; set; }
        public float AvgvisKm { get; set; }
        public float AvgvisMiles { get; set; }
        public float Avghumidity { get; set; }
        public Condition Condition { get; set; }
        public float uv { get; set; }
    }

    public class Astro
    {
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string Moonrise { get; set; }
        public string Moonset { get; set; }
    }

    public class Alert
    {
    }

}
