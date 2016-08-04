using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Explorer.DomainClasses.WebMenu.Attributes;

namespace Explorer.Web.Mvc.Controllers
{
     [MainSection(Order = 1300)]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
          [Detail(GroupName = "Basic")]
        [Authorize]
        public ActionResult Index()
        {
            return View("Secure");
        }

    }
}
