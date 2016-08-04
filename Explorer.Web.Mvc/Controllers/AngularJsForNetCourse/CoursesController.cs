using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Explorer.Web.Mvc.ViewModels.AngularJsForNetCourse.Registration;

namespace Explorer.Web.Mvc.Controllers.AngularJsForNetCourse
{
    public class CoursesController : JsonController
    {
        private RegistrationVmBuilder _registrationVmBuilder = new RegistrationVmBuilder();

        public ActionResult Index()
        {
            return Json(_registrationVmBuilder.GetCourseVms(), JsonRequestBehavior.AllowGet);
        }

    }
}
