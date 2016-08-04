using System.Collections.Generic;

namespace Explorer.Models.WebMenu.Models
{
    public class Menu
    {
        public List<MenuItem> MenuItems { get; set; }

        public List<Menu> Menus { get; set; } 
        public Menu()
        {
            MenuItems = new List<MenuItem>();
            Menus = new List<Menu>();
        }

        public string Name { get; set; }

    }
}