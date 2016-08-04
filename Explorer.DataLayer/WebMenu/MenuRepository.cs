using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Explorer.DomainClasses.WebMenu.Attributes;
using Explorer.DomainClasses.WebMenu.Models;

namespace Explorer.DataLayer.WebMenu
{
    public class MenuRepository : IWebMenuRepository
    {

        public Assembly TargetAssembly { get; set; }

        public MenuRepository(Assembly targetAssembly)
        {
            TargetAssembly = targetAssembly;
        }
        public Menu[] GetLeftNavigation()
        {
            // Find all classes with Main Section attribute in current Assembly
           // TargetAssembly.
            var types = from type in TargetAssembly.GetTypes()
                where Attribute.IsDefined(type, typeof (MainSectionAttribute))
                let temp = ((MainSectionAttribute) type.GetCustomAttributes(typeof(MainSectionAttribute)).First()).Order
                orderby temp descending
                select type;

            List<Menu> menus = new List<Menu>();

            foreach (var mainTarget in types)
            {
                // Remove the name controller
                // duh

                Menu controllerMenu = new Menu();
                var mainSecAttribute =
                    ((MainSectionAttribute)
                        mainTarget.GetCustomAttributes(typeof (MainSectionAttribute)).FirstOrDefault());
                string controllerName = mainTarget.Name.Replace("Controller", "");
                controllerMenu.Name = string.IsNullOrEmpty(mainSecAttribute.Name)
                    ? controllerName
                    : mainSecAttribute.Name;
                // Now Find each group name in current Type
                var methods = mainTarget.GetMethods().Where(x => x.IsDefined(typeof (DetailAttribute), false));
                var groups = new Dictionary<string, Menu>();
                foreach (var method in methods)
                {
                    DetailAttribute detail =
                        (DetailAttribute) Attribute.GetCustomAttribute(method, typeof (DetailAttribute));
                    Menu subMenu;
                    if (!groups.ContainsKey(detail.GroupName))
                    {
                        subMenu = new Menu();
                        controllerMenu.Menus.Add(subMenu);
                        subMenu.Name = detail.GroupName;
                        groups[detail.GroupName] = subMenu;
                    }
                    else
                    {
                        subMenu = groups[detail.GroupName];
                    }
                    subMenu.MenuItems.Add(new MenuItem
                    {
                        ActionName = method.Name,
                        ControllerName = controllerName,
                        Name = method.Name
                    });
                }
                menus.Add(controllerMenu);
            }
            return menus.ToArray();
        }
    }
}
