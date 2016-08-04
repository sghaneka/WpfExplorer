using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Explorer.Web.Mvc
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var razorEngine = ViewEngines.Engines.OfType<RazorViewEngine>().First();
            razorEngine.ViewLocationFormats = razorEngine.ViewLocationFormats.Concat(new string[]
            {
            "~/Views/{1}/{0}.cshtml", 
            "~/Views/Shared/{0}.cshtml", 
            "~/Views/PluralSight/AngularJsForNet/{1}/{0}.cshtml", 
            "~/Views/PluralSight/AngularJsFundamentals/{1}/{0}.cshtml", 
            "~/Views/Books/ProAngularBook/{1}/{0}.cshtml",
            "~/Views/Books/UDACity_JavaScriptDesignPatterns/{1}/{0}.cshtml",
            "~/Views/Books/LearningAngularJS/{1}/{0}.cshtml"

            }).ToArray();
        }
    }
}