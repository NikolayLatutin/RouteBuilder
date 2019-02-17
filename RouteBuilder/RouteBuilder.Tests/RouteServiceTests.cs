using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using RouteBuilder.Core.Implementations;
using RouteBuilder.Core.Interfaces;
using RouteBuilder.Core.Models;

namespace RouteBuilder.Tests
{

    [TestFixture]
    class RouteServiceTests
    {
        private IRouteService _routeService;
        private Mock<ISwaggerWrapper> _moqSwaggerWrapper;
        private Mock<IAirlineService> _moqAirlineService;

        public RouteServiceTests()
        {
            IHttpClientWrapper httpClientWrapper = new HttpClientWrapper();
            ISwaggerWrapper swaggerWrapper = new SwaggerWrapper(httpClientWrapper);
            IAirlineService airlineService = new AirlineService(swaggerWrapper);
            _routeService = new RouteService(swaggerWrapper, airlineService);
        }

        [Test]
        public void FoundRoutes_Test()
        {
            //arrange
            Init();
            _routeService = new RouteService(_moqSwaggerWrapper.Object, _moqAirlineService.Object);

            //act
            var result = _routeService.FoundRoutes("PKR", "BKK");

            //assert
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Count == 3);
            Assert.IsTrue(result[0].First.Value.SrcAirport == "PKR");
            Assert.IsTrue(result[0].Last.Value.DestAirport == "BKK");
        }

        private void Init()
        {
            _moqSwaggerWrapper = new Mock<ISwaggerWrapper>();
            _moqAirlineService = new Mock<IAirlineService>();

            var pkrRoute = new List<Route>
            {
                new Route
                {
                    Airline = "YT",
                    SrcAirport = "PKR",
                    DestAirport = "KTM"
                }
            };
            _moqSwaggerWrapper.Setup(sw => sw.GetRoutes("PKR"))
                .Returns(pkrRoute);

            var ktmRoute = new List<Route>
            {
                new Route
                {
                    Airline = "4H",
                    SrcAirport = "KTM",
                    DestAirport = "DAC"
                }
            };
            _moqSwaggerWrapper.Setup(sw => sw.GetRoutes("KTM"))
                .Returns(ktmRoute);

            var dacRoute = new List<Route>
            {
                new Route
                {
                    Airline = "4H",
                    SrcAirport = "DAC",
                    DestAirport = "BKK"
                }
            };
            _moqSwaggerWrapper.Setup(sw => sw.GetRoutes("DAC"))
                .Returns(dacRoute);

            _moqAirlineService.Setup(airs => airs.AirlineIsActive(It.IsAny<string>()))
                .Returns(true);

        }
    }
}
