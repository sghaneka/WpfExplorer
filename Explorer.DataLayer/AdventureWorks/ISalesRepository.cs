using System.Collections.Generic;
using System.Linq;

namespace Explorer.DataLayer.AdventureWorks
{
    public interface ISalesRepository
    {
        IEnumerable<Customer> GetAllCustomers();

        IQueryable<Customer> Customers { get; }
    }


}
