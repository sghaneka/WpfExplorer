using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Explorer.DomainClasses.WebMenu.Attributes;

namespace Explorer.Web.Mvc.Controllers.UDACity_JavaScriptDesignPatterns
{
    [MainSection(Order = 9900, Name = "UDACity JavaScript Design Patterns")]
    public class UDACityController : Controller
    {
        //
        // GET: /UDACity/
        [Detail(GroupName = "Basic")]
        public ActionResult CatClicker2()
        {
            return View("CatClicker2");
        }

        [Detail(GroupName = "Basic")]
        public ActionResult CatClicker3()
        {
            return View("CatClicker3");
        }

        [Detail(GroupName = "MVC Demo")]
        public ActionResult Retain()
        {
            return View("Retain");
        }

        [Detail(GroupName = "MVC Demo")]
        public ActionResult CatClickerMVC()
        {
            return View("CatClickerMVC");
        }

        [Detail(GroupName = "MVC Demo")]
        public ActionResult SchoolMVC()
        {
            return View("SchoolMVC");
        }

        [Detail(GroupName = "MVC Demo")]
        public ActionResult SchoolMVCAngular()
        {
            return View("SchoolMVCAngular");
        }

        [Detail(GroupName = "MVC Demo")]
        public ActionResult CatClickerMVCAngular()
        {
            return View("CatClickerMVCAngular");
        }

    }
}
