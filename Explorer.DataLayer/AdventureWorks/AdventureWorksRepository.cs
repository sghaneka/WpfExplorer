using System.Collections.Generic;
using System.Linq;

namespace Explorer.DataLayer.AdventureWorks
{
    public class AdventureWorksRepository : ISalesRepository
    {
        private IAdventureWorksContext _context;

        public AdventureWorksRepository(IAdventureWorksContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var items = from cust in _context.Customers
                        orderby cust.LastName
                        select cust;
            return items.ToList();
        }

        public IQueryable<Customer> Customers
        {
            get { return _context.Customers; }
        }
    }
}
