using System.Web.Http;
using RouteBuilder.Api.Models;
using RouteBuilder.Core.Interfaces;


namespace RouteBuilder.Api.Controllers
{
    public class RouteController : ApiController
    {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet]
        public IHttpActionResult GetRoute(GetRoute request)
        {
            var routes = _routeService.FoundRoutes(request.StartPoint, request.FinishPioint);

            return Ok();
        }

    }
}
