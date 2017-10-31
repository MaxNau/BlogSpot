using BlogSpot.Api.Utils;
using Owin;
using System.Net.Http.Headers;
using System.Web.Http;

namespace BlogSpot.Api
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            IDependencyInjector injector = new DependencyInjector();

            app.UseWebApi(ConfigureWebApi(injector));
        }

        private HttpConfiguration ConfigureWebApi(IDependencyInjector injector)
        {
            var config = new HttpConfiguration();

            config.DependencyResolver = new UnityDependencyResolver(injector.GetDependencyContainer);

            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            return config;
        }
    }
}