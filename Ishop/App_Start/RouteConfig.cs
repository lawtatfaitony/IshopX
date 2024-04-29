using Ishop.Context;
using LanguageResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ishop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes,string languageCode)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
             
            routes.MapRoute(
                        name: "Default",
                        url: "{Language}/{controller}/{action}/{id}",
                        constraints: new { Language = "zh-HK|zh-CN|en-US|hk|cn|en|HK|CN|EN" },
                        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, Language = languageCode }   //   constraints: new { Language = "zh-HK|zh-CN|en-US" }, 
                    );
             
        }

    } 
}
