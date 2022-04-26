using System.Web.Mvc;
using System.Web.Routing;

namespace EntityFrameworkUsage
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "MyArea",
            //    url: "HelpPage/{controller}/{action}/{id?}",
            //    defaults: new { controller = "Help", action = "Index", id = UrlParameter.Optional });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
