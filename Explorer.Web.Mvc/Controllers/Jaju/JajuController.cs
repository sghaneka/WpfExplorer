using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace Explorer.Web.Mvc.Controllers.Jaju
{
    public class JajuController : JsonController
    {
        [System.Web.Mvc.HttpGet]
        public ActionResult LongRunningRequest(int sleepTime = 10)
        {
            Thread.Sleep(sleepTime);
            return Json("janvi", JsonRequestBehavior.AllowGet);
        }

        public ActionResult LongRunningRequestWithError(int sleepTime = 10)
        {
            Thread.Sleep(sleepTime);
            return HttpNotFound("I did not find message goes here");
        }
    }
}
