using System.Collections.Generic;
using Explorer.DomainClasses.WebMenu.Models;

namespace Explorer.DataLayer.WebMenu
{
    public class FakeMenuRepository : IWebMenuRepository
    {
        public Menu[] GetLeftNavigation()
        {
           List<Menu> menus = new List<Menu>();
            Menu m1 = new Menu();
            m1.Name = "Knockout";
          //  m1.MenuItems = new List<MenuItem>();
           // m1.MenuItems.Add(new MenuItem {ActionName = "action1", ControllerName = "control1", Name = "highleveldemo1"});
           // m1.MenuItems.Add(new MenuItem { ActionName = "action2", ControllerName = "control2", Name = "highleveldemo2" });
           // m1.MenuItems.Add(new MenuItem { ActionName = "action3", ControllerName = "control3", Name = "highleveldemo3" });
            m1.Menus = new List<Menu>();
            Menu m2 = new Menu();
            m2.Name = "Basic";
            Menu m3 = new Menu();
            m3.Name = "Advanced";
            m1.Menus.Add(m2);
            m1.Menus.Add(m3);
            m2.MenuItems.Add(new MenuItem { ActionName = "Example1", ControllerName = "Knockout", Name = "Example 1" });
            m2.MenuItems.Add(new MenuItem { ActionName = "ContactManager", ControllerName = "Knockout", Name = "ContactManager" });
            m2.MenuItems.Add(new MenuItem { ActionName = "action3", ControllerName = "control3", Name = "highleveldemo3" });

            m3.MenuItems.Add(new MenuItem { ActionName = "action1", ControllerName = "control1", Name = "highleveldemo1" });
            m3.MenuItems.Add(new MenuItem { ActionName = "action2", ControllerName = "control2", Name = "highleveldemo2" });
            m3.MenuItems.Add(new MenuItem { ActionName = "action3", ControllerName = "control3", Name = "highleveldemo3" });

            Menu m4 = new Menu();
            m4.Name = "Knockout2";
            m4.MenuItems = new List<MenuItem>();
           // m4.MenuItems.Add(new MenuItem { ActionName = "action1", ControllerName = "control1", Name = "highleveldemo1" });
           // m4.MenuItems.Add(new MenuItem { ActionName = "action2", ControllerName = "control2", Name = "highleveldemo2" });
           // m4.MenuItems.Add(new MenuItem { ActionName = "action3", ControllerName = "control3", Name = "highleveldemo3" });
            m4.Menus = new List<Menu>();

            menus.Add(m1);
            menus.Add(m4);

            return menus.ToArray();
        }
    }
}
