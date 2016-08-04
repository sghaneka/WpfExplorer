using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Explorer.DomainClasses.WebMenu.Attributes;

namespace Explorer.Web.Mvc.Controllers.LearningAngularJS
{
    [MainSection(Order = 1666)]
    public class Lesson1Controller : Controller
    {
        //
        // GET: /Lesson1/

        [Detail(GroupName = "Basic")]
        public ActionResult MultipleControllers()
        {
            return View("MultipleControllers");
        }

        [Detail(GroupName = "Basic")]
        public ActionResult Arrays()
        {
            return View("Arrays");
        }

        [Detail(GroupName = "Basic")]
        public ActionResult NestedControllers()
        {
            return View("NestedControllers");
        }

    }
}
