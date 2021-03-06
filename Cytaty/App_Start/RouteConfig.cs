﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cytaty
{

    //plik definiuje router, jak serwer ma przetwarzać moje żadanie
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //domyslny kontroler i akcja
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Cytaty", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
