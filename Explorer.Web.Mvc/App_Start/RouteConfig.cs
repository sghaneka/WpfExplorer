using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Explorer.Web.Mvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Registration SPA Courses Ajax",
                url: "Angular/RegistrationAjax/Courses",
                defaults: new { controller = "Angular", action = "AjaxRequestOfData_MiniSpa" }
            );

            routes.MapRoute(
                name: "Registration SPA Instructors Ajax",
                url: "Angular/RegistrationAjax/Instructors",
                defaults: new { controller = "Angular", action = "AjaxRequestOfData_MiniSpa" }
            );

            routes.MapRoute(
                name: "Registration SPA Courses",
                url: "Angular/RegistrationBootStrap/Courses",
                defaults: new { controller = "Angular", action = "BootStrapOfData_MiniSpa" }
            );

            routes.MapRoute(
                name: "Registration SPA Instructors",
                url: "Angular/RegistrationBootStrap/Instructors",
                defaults: new { controller = "Angular", action = "BootStrapOfData_MiniSpa" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Explorer.Web.Mvc.Controllers" }
            );

           
        }
    }
}