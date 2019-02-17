using Newtonsoft.Json;

namespace RouteBuilder.Core.Models
{
    public class Airline
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }
    }
}