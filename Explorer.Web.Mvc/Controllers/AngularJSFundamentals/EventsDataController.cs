using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Explorer.Web.Mvc.ViewModels.AngularJSFundamentals;

namespace Explorer.Web.Mvc.Controllers.AngularJSFundamentals
{
    public class EventsDataController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<EventsVm> Get()
        {
            EventsVmBuilder temp = new EventsVmBuilder();
            return new EventsVm[] {temp.BuildVm()};
        }

        // GET api/<controller>/5
        public EventsVm Get(int id)
        {
            EventsVmBuilder temp = new EventsVmBuilder();
            return temp.BuildVm();
        }

        // POST api/<controller>
        public void Post([FromBody]EventsVm value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]EventsVm value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}