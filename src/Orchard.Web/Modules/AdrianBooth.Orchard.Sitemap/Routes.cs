using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace AdrianBooth.Orchard.Sitemap
{
    public class Routes : IRouteProvider
    {
        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            yield return new RouteDescriptor
            {
                Priority = 1,
                Route = new Route(
                     "Sitemap.xml",
                     new RouteValueDictionary {
                        {"area", "AdrianBooth.Orchard.Sitemap"},
                        {"controller", "Sitemap"},
                        {"action", "Index"}
                     },
                     new RouteValueDictionary(),
                     new RouteValueDictionary {
                        {"area", "AdrianBooth.Orchard.Sitemap"}
                     },
                     new MvcRouteHandler())
            };
        }

        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }
    }
}