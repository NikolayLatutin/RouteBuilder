using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteBuilder.Core.Interfaces;
using RouteBuilder.Core.Models;

namespace RouteBuilder.Core.Implementations
{
    public class RouteService : IRouteService
    {
        private readonly ISwaggerWrapper _swaggerWrapper;
        private readonly IAirlineService _airlineService;
        private List<LinkedList<Route>> _paths;
        private string _goal;

        public RouteService(ISwaggerWrapper swaggerWrapper, IAirlineService airlineService)
        {
            _swaggerWrapper = swaggerWrapper;
            _airlineService = airlineService;
        }

        public List<LinkedList<Route>> FoundRoutes(string srcAirport, string destAirport)
        {
            var starts = _swaggerWrapper.GetRoutes(srcAirport);

            if (starts == null || !starts.Any())
                throw new ArgumentException("Routes list for airport is empty");

            _goal = destAirport;
            _paths = new List<LinkedList<Route>>();

            Parallel.ForEach(starts, InitPath);

            return _paths;
        }

        private void InitPath(Route start)
        {
            var path = new LinkedList<Route>();

            if (AddPathSteps(start.SrcAirport, path))
            {
                _paths.Add(path);
            }
        }

        private bool AddPathSteps(string srcAirport, LinkedList<Route> path)
        {
            var routes = _swaggerWrapper.GetRoutes(srcAirport);

            if (srcAirport == _goal)
                return true;

            foreach (var route in routes)
            {
                if (!_airlineService.AirlineIsActive(route.Airline))
                    continue;

                if (AddPathSteps(route.DestAirport, path))
                {
                    path.AddFirst(route);
                    return true;
                }
            }
            return false;
        }
    }
}