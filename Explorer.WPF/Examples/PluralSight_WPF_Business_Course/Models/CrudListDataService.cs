using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.DataLayer.AdventureWorks;

namespace Explorer.WPF.Examples.PluralSight_WPF_Business_Course.Models
{
    public class CrudListDataService
    {
        private IEnumerable<Customer> _customers;

        public CrudListDataService()
        {
            _customers = new List<Customer>
            {
                new Customer
                {
                    CustomerID = 1,
                    FirstName = "CustomerFirst1",
                    LastName = "CustomerLast1",
                    CompanyName = "CustomerCompany1",
                    EmailAddress = "customer1@myinc.com"
                },
                new Customer
                {
                    CustomerID = 2,
                    FirstName = "CustomerFirst2",
                    LastName = "CustomerLast2",
                    CompanyName = "CustomerCompany2",
                    EmailAddress = "customer2@myinc.com"
                },
                new Customer
                {
                    CustomerID = 3,
                    FirstName = "CustomerFirst3",
                    LastName = "CustomerLast3",
                    CompanyName = "CustomerCompany3",
                    EmailAddress = "customer3@myinc.com"
                },
                new Customer
                {
                    CustomerID = 4,
                    FirstName = "CustomerFirst4",
                    LastName = "CustomerLast4",
                    CompanyName = "CustomerCompany4",
                    EmailAddress = "customer4@myinc.com"
                }

            };
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customers;
        }
    }
}
