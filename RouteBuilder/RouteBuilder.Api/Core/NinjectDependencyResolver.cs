using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Ninject;
using RouteBuilder.Core.Implementations;
using RouteBuilder.Core.Interfaces;

namespace RouteBuilder.Api.Core
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;
        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        private void AddBindings()
        {
            _kernel.Bind<IRouteService>().To<RouteService>();
            _kernel.Bind<IAirlineService>().To<AirlineService>();
            _kernel.Bind<ISwaggerWrapper>().To<SwaggerWrapper>();
            _kernel.Bind<IHttpClientWrapper>().To<HttpClientWrapper>();
        }

        public void Dispose()
        {
        }
    }


}