using System;

namespace Explorer.Models.WebMenu.Attributes
{
    public class MainSectionAttribute : Attribute
    {
        public int Order { get; set; }

        public string Name { get; set; }
    }
}
