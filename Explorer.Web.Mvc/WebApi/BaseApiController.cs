using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Explorer.DataLayer;
using Explorer.DataLayer.AdventureWorks;
using Explorer.Web.Mvc.ViewModels;

namespace Explorer.Web.Mvc.WebApi
{
    public abstract class BaseApiController : ApiController
    {
        private ISalesRepository _repo;
        ModelFactory _modelFactory;

        public BaseApiController(ISalesRepository repo)
        {
            _repo = repo;
        }

        protected ISalesRepository TheRepository
        {
            get { return _repo; }
        }

        protected ModelFactory TheModelFactory
        {
            get { return _modelFactory ?? (_modelFactory = new ModelFactory(this.Request)); }
        }
    }
}