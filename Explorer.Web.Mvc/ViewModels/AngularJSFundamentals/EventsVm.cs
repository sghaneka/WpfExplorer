using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Explorer.Web.Mvc.ViewModels.AngularJSFundamentals
{
    public class EventsVm
    {
        public string Date { get; set; }

        public string ImageUrl { get; set; }

        public AddressVm Location { get; set; }

        public SessionDetail[] Sessions { get; set; }

        public class AddressVm
        {
            public string Address { get; set; }
            public string City { get; set; }
            public string Province { get; set; }
        }

        public class SessionDetail
        {
            public string Abstract { get; set; }

            public string CreatorName { get; set; }

            public int Duration { get; set; }

            public string Level { get; set; }

            public string Name { get; set; }

            public int UpVoteCount { get; set; }
        }

        public string Name { get; set; }

        public string Time { get; set; }
    }


}