using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Explorer.DomainClasses.WebMenu.Models;

namespace Explorer.Web.Mvc.ViewModels
{
    public class LeftNavMenuModel
    {
        public Menu[] LeftNavMenu { get; set; }

        public string ActionName { get; set; }
        public string Controller { get; set; }
    }
}