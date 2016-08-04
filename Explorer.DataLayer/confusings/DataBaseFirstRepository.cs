using System.Collections.Generic;
using System.Linq;
using Explorer.DataLayer.AdventureWorks;

namespace Explorer.DataLayer.confusings
{
    public class DatabaseFirstRepository : ISalesRepository
    {
       // private AdventureWorksLT2012Entities _salesContext = new AdventureWorksLT2012Entities();

        //private readonly AdventureWorksLT2012Entities _salesContext = new AdventureWorksLT2012Entities();
        private readonly IUnitOfWork<AdventureWorks.AdventureWorksContext> _UnitOfWork;

        public DatabaseFirstRepository(IUnitOfWork<AdventureWorks.AdventureWorksContext> uow)
        {
            _UnitOfWork = uow;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var items = from cust in _UnitOfWork.Context.Customers
                        orderby cust.LastName
                        select cust;
            return items.ToList();
        }

        public IQueryable<Customer> Customers
        {
            get { return _UnitOfWork.Context.Customers; }
        }

        public AdventureWorks.AdventureWorksContext Context
        {
            get { return _UnitOfWork.Context; }
        }


    }
}
