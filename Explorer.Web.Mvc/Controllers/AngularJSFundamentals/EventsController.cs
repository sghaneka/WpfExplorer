using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Explorer.DomainClasses.WebMenu.Attributes;

namespace Explorer.Web.Mvc.Controllers.AngularJSFundamentals
{
    [MainSection(Order = 1200)]
    public class EventsController : JsonController
    {
        //
        // GET: /Events/

         [Detail(GroupName = "Basic")]
        public ActionResult Index()
        {
            return View("EventDetails");
        }

        public ActionResult NewEvent()
        {
            return View("NewEvent");
        }

        [Detail(GroupName = "Basic")]
        public ActionResult EditProfile()
        {
            return View("EditProfile");
        }
    }
}
