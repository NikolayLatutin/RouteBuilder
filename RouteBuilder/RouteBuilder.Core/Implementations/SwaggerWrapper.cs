using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RouteBuilder.Core.Interfaces;
using RouteBuilder.Core.Models;

namespace RouteBuilder.Core.Implementations
{
    public class SwaggerWrapper: ISwaggerWrapper
    {
        private readonly IHttpClientWrapper _httpClientWrapper;
        private readonly string _host;
        private readonly string _airlineEndpoint;
        private readonly string _routeEndpoint;
        private readonly string _airportEndpoint;

        public SwaggerWrapper(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
            _host = AppConfigurationHelper.GetHost();
            _airlineEndpoint = AppConfigurationHelper.GetAirlineEndpoint();
            _routeEndpoint = AppConfigurationHelper.GetRouteEndpoint();
            _airportEndpoint = AppConfigurationHelper.GetAirportEndpoint();
        }

        public Airline GetAirlineDate(string alias)
        {
            var url = $"{_host}{_airlineEndpoint}/{alias}";
            var request = _httpClientWrapper.MakeGetRequest(url, new Dictionary<string, string>());

            var result = JsonConvert.DeserializeObject<IList<Airline>>(request)
                .FirstOrDefault();
            return result;
        }

        public IList<Route> GetRoutes(string airport)
        {
            var url = $"{_host}{_routeEndpoint}?airport={airport}";
            var request = _httpClientWrapper.MakeGetRequest(url, new Dictionary<string, string>());

            var result = JsonConvert.DeserializeObject<IList<Route>>(request);
            return result;
        }

        public Route GetRoute(string airport)
        {
            var url = $"{_host}{_routeEndpoint}?airport={airport}";
            var request = _httpClientWrapper.MakeGetRequest(url, new Dictionary<string, string>());

            var result = JsonConvert.DeserializeObject<IList<Route>>(request)
                .FirstOrDefault();
            return result;
        }

        public Airport GetAirportDate(string pattern)
        {
            var url = $"{_host}{_airportEndpoint}?pattern={pattern}";
            var request = _httpClientWrapper.MakeGetRequest(url, new Dictionary<string, string>());

            var result = JsonConvert.DeserializeObject<IList<Airport>>(request)
                .FirstOrDefault();
            return result;
        }
    }
}