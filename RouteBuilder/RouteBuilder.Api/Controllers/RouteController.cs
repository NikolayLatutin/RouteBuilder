using System;
using System.Net;
using System.Net.Http;
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
        public HttpResponseMessage GetRoute(Route request)
        {
            try
            {
                var routes = _routeService.FoundRoutes(request.StartPoint, request.FinishPioint);
                var response = Request.CreateResponse(HttpStatusCode.OK, routes);
                return response;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            
        }

    }
}
