using AutoMapper;
using BlogSpot.Api.DAL.Entities;
using BlogSpot.Api.DTOs;
using BlogSpot.Api.Profiles;
using BlogSpot.Api.Utils;
using Owin;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BlogSpot.Api
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            IDependencyInjector injector = new DependencyInjector();
            ConfigureAutomapper();
            app.UseWebApi(ConfigureWebApi(injector));
        }

        private HttpConfiguration ConfigureWebApi(IDependencyInjector injector)
        {
            var config = new HttpConfiguration();

            config.DependencyResolver = new UnityDependencyResolver(injector.GetDependencyContainer);

            config.MapHttpAttributeRoutes();

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            var enableCors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(enableCors);

            return config;
        }

        private void ConfigureAutomapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(new[]
                {
                  typeof(PostProfile),
                  typeof(CategoryProfile),
                  typeof(TagProfile)
                });
            });
        }
    }
}