using System.Collections.Generic;
using RouteBuilder.Core.Models;

namespace RouteBuilder.Core.Interfaces
{
    public interface IRouteService
    {
        List<LinkedList<Route>> FoundRoutes(string srcAirport, string destAirport);
    }
}