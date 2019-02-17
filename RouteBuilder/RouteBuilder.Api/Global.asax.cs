using System.Web.Http;
using Ninject;
using RouteBuilder.Api.Core;

namespace RouteBuilder.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
            var kernel = new StandardKernel();
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
            
        }
    }
}
