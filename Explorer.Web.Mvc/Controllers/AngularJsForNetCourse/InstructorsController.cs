using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Explorer.DataLayer.AngularJsForNetCourse;
using Explorer.Web.Mvc.ViewModels.AngularJsForNetCourse.Registration;

namespace Explorer.Web.Mvc.Controllers.AngularJsForNetCourse
{
    public class InstructorsController : JsonController
    {
        private ICourseRepository _repository;

        private RegistrationVmBuilder _registrationVmBuilder = new RegistrationVmBuilder();

        public InstructorsController(ICourseRepository repo)
        {
            _repository = repo;
        }

        public ActionResult Index()
        {
            //return Json(_repository.GetCourses(), JsonRequestBehavior.AllowGet);
            return Json(_registrationVmBuilder.GetInstructorVms(), JsonRequestBehavior.AllowGet);
        }

    }
}
