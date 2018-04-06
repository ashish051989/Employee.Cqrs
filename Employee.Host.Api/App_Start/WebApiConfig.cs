using Employee.Configuration;
using Microsoft.Practices.Unity;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace Employee.Host.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
            name: "swagger_root", 
            routeTemplate: "", 
            defaults: null, 
            constraints: null,
            handler: new RedirectHandler((message => message.RequestUri.ToString()), "swagger")); 

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }

        public class UnityResolver : IDependencyResolver
        {
            private readonly IUnityContainer container;

            public UnityResolver(IUnityContainer container)
            {
                this.container = container;
            }

            public IDependencyScope BeginScope()
            {
                var child = container.CreateChildContainer();
                return new UnityResolver(child);
            }

            public void Dispose()
            {
                container.Dispose();
            }

            public object GetService(Type serviceType)
            {
                if (container.IsRegistered(serviceType))
                    return container.Resolve(serviceType);
                else
                    return null;
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                if (container.IsRegistered(serviceType))
                    return container.ResolveAll(serviceType);
                else
                    return new List<object>();
            }
        }
    }
}
