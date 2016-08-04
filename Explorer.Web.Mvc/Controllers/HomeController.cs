using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Explorer.DataLayer;
using Explorer.DataLayer.WebMenu;
using Explorer.Web.Mvc.ViewModels;

namespace Explorer.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {

        private IWebMenuRepository _repository;
        //
        // GET: /Home/

        public HomeController(IWebMenuRepository repo)
        {
            _repository = repo;
            //MenuRepository = new MenuRepository(Assembly.GetExecutingAssembly());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult LeftNavMenu(string controllerName, string actionName)
        {
            LeftNavMenuModel menuModel = new LeftNavMenuModel();
            menuModel.LeftNavMenu = _repository.GetLeftNavigation();
            menuModel.ActionName = actionName;
            menuModel.Controller = controllerName;
            return View(menuModel);
        }

    }
}
