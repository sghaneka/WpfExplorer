using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Explorer.DomainClasses.WebMenu.Attributes;

namespace Explorer.Web.Mvc.Controllers.Knockout
{
    [MainSection]
    public class KnockoutController : Controller
    {
        //
        // GET: /Knockout/

        [Detail(GroupName="Basic")]
        public ActionResult Example1()
        {
            return View();
        }

        [Detail(GroupName = "Basic1")]
        public ActionResult ContactManager()
        {
            return View();
        }

    }
}
