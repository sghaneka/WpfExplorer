using System;
using System.Data.Entity;
using System.Linq;
using Explorer.DataLayer.AdventureWorks;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


//  http://mylifeandcode.blogspot.com/2012/10/unit-testing-with-mock-entity-framework.html
namespace Explorer.DataLayer.Test
{
    [TestClass]
    public class SalesRepositoryTest
    {


        [TestMethod]
        public void GetCustomersReturnsCustomers()
        {
            var context = new FakeAdventureWorksContext();
            context.Customers.Add(new Customer{ FirstName = "Sam", LastName = "Harrington"});
            context.Customers.Add(new Customer { FirstName = "Julie", LastName = "Carpenter" });
            context.Customers.Add(new Customer { FirstName = "Ted", LastName = "Zeals" });

            var advRep = new AdventureWorksRepository(context);
            var customers = advRep.Customers.ToList();
            Assert.IsTrue(customers.Count== 3, "There should be three");
        }


        public void GetCustomersReturnsCustomersForTheRealDeal()
        {
            int totalCustomers;
            using (var ctx = new AdventureWorks.AdventureWorksContext())
            {
                totalCustomers = ctx.Customers.Count();
            }
            Console.WriteLine(totalCustomers);

        }
    }

    public class FakeCustomerSet : FakeDbSet<Customer>
    {
        
    }

    public class FakeAdventureWorksContext : IAdventureWorksContext
    {
        public FakeAdventureWorksContext()
        {
            this.Customers = new FakeDbSet<Customer>();
        }

        public IDbSet<Customer> Customers { get; set; }
        public int SaveChanges()
        {
            return 0;
        }


        public IDbSet<StatesReference> StatesReferences
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }


}
