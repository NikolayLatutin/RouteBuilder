using RouteBuilder.Core.Interfaces;

namespace RouteBuilder.Core.Implementations
{
    public class AirlineService: IAirlineService
    {
        private readonly ISwaggerWrapper _swaggerWrapper;

        public AirlineService(ISwaggerWrapper swaggerWrapper)
        {
            _swaggerWrapper = swaggerWrapper;
        }

        public bool AirlineIsActive(string airlineAlias)
        {
            var airline = _swaggerWrapper.GetAirlineDate(airlineAlias);
            var result = airline.Active;
            return result;
        }
    }
}