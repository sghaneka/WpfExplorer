using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Explorer.DomainClasses.WebMenu.Attributes;

namespace Explorer.Web.Mvc.Controllers.ProAngularBook
{
    [MainSection(Order=100, Name="ProAngularBook(ToDoList)")]
    public class ProAngularCompleteController : Controller
    {
        //
        // GET: /Ch1ToDo/

         [Detail(GroupName = "ToDoList")]
         public ActionResult Index()
         {
             return View();
         }

         [Detail(GroupName = "SportsStore")]
         public ActionResult SportsStore()
         {
             return View();
         }

         [Detail(GroupName = "Basic")]
         public ActionResult Anatomy()
         {
             return View();
         }

         [Detail(GroupName = "Basic")]
         public ActionResult ElementAndEventDirectives()
         {
             return View();
         }

         [Detail(GroupName = "Basic")]
         public ActionResult MonolithicController()
         {
             return View();
         }


         [Detail(GroupName = "Forms")]
         public ActionResult WorkingWithForms()
         {
             return View();
         }

         [Detail(GroupName = "Forms")]
         public ActionResult FormValidation()
         {
             return View();
         }

    }
}
