using System.Web.Http;
using Windsor.Commons.AspNet.WebApi.Filters;
using Windsor.OpenNode2.RestEndpoint.Filters;

namespace Windsor.OpenNode2.RestEndpoint
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.DependencyResolver = new SpringWebApiDependencyResolver();

            // Routes
            config.Routes.MapHttpRoute(
                name: "MethodApi",
                routeTemplate: "{controller}",
                defaults: null,
                constraints:
                new
                {
                    controller = @"(?i)(query|solicit)"
                }
            );

            // Filters
            config.Filters.Add(new UnhandledExceptionFilterAttribute());
            OrderableFilterProvider.Register(GlobalConfiguration.Configuration);
        }
    }
}
