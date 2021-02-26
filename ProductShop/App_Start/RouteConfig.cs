using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProductShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            //routes.MapRoute("Default", "{controller}/{action}/{id}",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional });
    
            routes.MapRoute("Localization", "{lang}/{controller}/{action}/{id}",
                constraints: new { lang= "zh-CN|en-US" },
                defaults: new { lang="en-US", controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
