using System;

namespace Explorer.DomainClasses.WebMenu.Attributes
{
    public class MainSectionAttribute : Attribute
    {
        public int Order { get; set; }

        public string Name { get; set; }
    }
}
