using Explorer.DomainClasses.WebMenu.Models;

namespace Explorer.DataLayer.WebMenu
{
    public interface IWebMenuRepository
    {
        Menu[] GetLeftNavigation();
    }
}
