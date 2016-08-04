using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Explorer.DataLayer;
using Explorer.DataLayer.AdventureWorks;
using Explorer.Web.Mvc.ViewModels;

namespace Explorer.Web.Mvc.WebApi
{
    public class CustomerController : BaseApiController
    {
        public CustomerController(ISalesRepository repo) : base(repo)
        {
        }

        public IEnumerable<CustomerModel> Get()
        {
            var results = TheRepository.GetAllCustomers().Select(x => TheModelFactory.Create(x));
            return results;
        } 
    }
}
