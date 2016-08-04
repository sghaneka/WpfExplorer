using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Explorer.DataLayer.WebMenu;
using Explorer.DomainClasses.WebMenu.Attributes;
using Explorer.DomainClasses.WebMenu.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Explorer.DataLayer.Test
{
    [TestClass]
    public class MenuRepositoryTest
    {
        [TestMethod]
        public void MenuRepositoryReturnsMenuHierarchyForAttributes()
        {
            MenuRepository mr = new MenuRepository(Assembly.GetExecutingAssembly());
            Menu[] menus = mr.GetLeftNavigation();
            var total = menus.Count(x => x.Name == "ThisIsNotADummy");
            Assert.AreEqual(total, 1, "Should be one of these controllers");
            total = menus.First(x => x.Name == "ThisIsNotADummy").Menus.Count(x => x.Name == "group1");
            Assert.AreEqual(total, 1, "Should be only 1 group1");
            var itemsInGroup1 =
                menus.First(x => x.Name == "ThisIsNotADummy")
                    .Menus.First(x => x.Name == "group1").MenuItems;
            Assert.IsTrue(itemsInGroup1.Any(x => x.Name == "Method1"), "Should have method1");
            Assert.IsTrue(itemsInGroup1.Any(x => x.Name == "Method2"), "Should have method2");
            Assert.IsTrue(itemsInGroup1.Any(x => x.Name == "Method3"), "Should have method3");



        }
    }

    [MainSection(Name="ThisIsNotADummy")]
    public class DummyController
    {
        [Detail(GroupName = "group1")]
        public void Method1(string abc, string def)
        {
            
        }

        [Detail(GroupName = "group1")]
        public void Method2(string abc, string def)
        {

        }

        [Detail(GroupName = "group1")]
        public void Method3(string abc, string def)
        {

        }

        [Detail(GroupName = "group2")]
        public void Method4(string abc, string def)
        {

        }

        public void Method5(string abc, string def)
        {

        }
    }

    [MainSection]
    public class Dummy2Controller
    {
        [Detail(GroupName = "group1")]
        public void Method1(string abc, string def)
        {

        }

        [Detail(GroupName = "group1")]
        public void Method2(string abc, string def)
        {

        }

        [Detail(GroupName = "group1")]
        public void Method3(string abc, string def)
        {

        }

        [Detail(GroupName = "group2")]
        public void Method4(string abc, string def)
        {

        }

        public void Method5(string abc, string def)
        {

        }
    }

    public class Dummy3Controller
    {
        public void Method5(string abc, string def)
        {

        }
    }
}
