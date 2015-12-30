using System.Web.Mvc;
using System.Web.Routing;

namespace RejestrFaktur
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //routes.MapRoute(
            // name: "SciezkaJednostkiMiary",
            // url: "{controller}/{id}/{stan}",
            // defaults: new { controller = "JednostkiMiary", action = "Index", id = UrlParameter.Optional, stan = UrlParameter.Optional }
            // );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );



        }
    }
}
