using System.Collections.Generic;
using RouteBuilder.Core.Models;

namespace RouteBuilder.Core.Interfaces
{
    public interface ISwaggerWrapper
    {
        Airline GetAirlineDate(string alias);

        IList<Route> GetRoutes(string airport);
        Route GetRoute(string airport);

        Airport GetAirportDate(string pattern);
    }
}