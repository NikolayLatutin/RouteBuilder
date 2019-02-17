using System.Collections.Generic;
using Newtonsoft.Json;

namespace RouteBuilder.Core.Models
{
    public class Route
    {
        [JsonProperty("airline")]
        public string Airline { get; set; }

        [JsonProperty("srcAirport")]
        public string SrcAirport { get; set; }

        [JsonProperty("destAirport")]
        public string DestAirport { get; set; }

        public List<Route> Transfers { get; set; }
    }
}