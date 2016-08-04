using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Explorer.DomainClasses.WebMenu.Attributes;
using Explorer.Web.Mvc.ViewModels.AngularJsForNetCourse.Registration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Explorer.Web.Mvc.Controllers.AngularJsForNetCourse
{
    [MainSection(Order = 1)]
    public class AngularController : Controller
    {

         private RegistrationVmBuilder _registrationVmBuilder = new RegistrationVmBuilder();
        //
        // GET: /Angular/

         [Detail(GroupName = "Basic")]
        public ActionResult ShowBasicBindingInTable()
        {
            return View("Index");
        }

         [Detail(GroupName = "Basic")]
         public ActionResult BootStrapOfData_UsingNgInit()
         {
             return View("BootStrapOfData_UsingNgInit", "", _registrationVmBuilder.GetSerializedCourseVms());
         }

         [Detail(GroupName = "Basic")]
         public ActionResult ContactManager()
         {
             return View();
         }

          [Detail(GroupName = "Basic")]
         public ActionResult BootStrapOfData_UsingService()
         {
             return View("BootStrapOfData_UsingService", "", _registrationVmBuilder.GetSerializedCourseVms());
         }

          [Detail(GroupName = "Basic")]
         public ActionResult BootStrapOfData_StoredInGlobal()
          {
              return View("BootStrapOfData_StoredInGlobal", "", _registrationVmBuilder.GetSerializedCourseVms());
          }

         [Detail(GroupName = "Basic")]
         public ActionResult BootStrapOfData_MiniSpa()
         {
             return View("BootStrapOfData_MiniSpa", "", _registrationVmBuilder.BuildRegistrationVm());
         }

         [Detail(GroupName = "Basic")]
         public ActionResult AjaxRequestOfData_MiniSpa()
         {
             return View();
         }

    }

}
