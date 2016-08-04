using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Explorer.DataLayer.AngularJsForNetCourse;
using Explorer.Web.Mvc.ViewModels.AngularJsForNetCourse.Instructors;
using Explorer.Web.Mvc.ViewModels.AngularJsForNetCourse.Registration;

namespace Explorer.Web.Mvc.Controllers.AngularJsForNetCourse
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        private ICourseRepository _repository;

        public AccountController(ICourseRepository repo)
        {
            _repository = repo;
        }


        [HttpPost]
        public ActionResult Save(InstructorVm instructor)
        {
           

            InstructorService service = InstructorService.GetInstance();
            service.AddInstructor(instructor);
            // Take this data and stuff it in
            return new HttpStatusCodeResult(HttpStatusCode.OK);
            //return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        }

    }
}
