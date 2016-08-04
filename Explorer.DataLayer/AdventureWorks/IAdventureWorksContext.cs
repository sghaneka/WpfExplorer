using System.Data.Entity;

namespace Explorer.DataLayer.AdventureWorks
{
    public interface IAdventureWorksContext
    {
        IDbSet<Customer> Customers { get; set; }
        IDbSet<StatesReference> StatesReferences { get; set; }
        int SaveChanges();
    }
}
