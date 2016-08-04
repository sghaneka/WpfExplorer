using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;

namespace Explorer.Web.Mvc.ViewModels.AngularJSFundamentals
{
    public class EventsVmBuilder
    {
        public EventsVm BuildVm()
        {
            EventsVm temp = new EventsVm
            {
                Date = "1/1/2013",
                Time = "10:30am",
                ImageUrl = "/myscripts/angularjs_fundamentals/img/angularjs-logo.png",
                Location = new EventsVm.AddressVm
                {
                    Address = "Google HeadQuarters",
                    City = "Mountain View",
                    Province = "CA"
                },
                Name = "Angular Boot Camp",
                Sessions = new EventsVm.SessionDetail[]
                {
                   new EventsVm.SessionDetail
                   {
                       Abstract = "In this sesison you will learn the ins and outs of directives!",
                       CreatorName = "Bob Smith",
                       Duration = 1,
                       Level = "Advanced",
                       Name = "Directives Masterclass",
                       UpVoteCount = 0
                   },
                   new EventsVm.SessionDetail
                   {
                       Abstract = "This session will take a closer look at scopes.  Learn what they do, how they do it, and how to get them to do it for you.",
                       CreatorName = "John Doe",
                       Duration = 2,
                       Level = "Introductory",
                       Name = "Scopes for fun and profit",
                       UpVoteCount = 0
                   },
                    new EventsVm.SessionDetail
                   {
                       Abstract = "Controllers are the beginning of everything Angular does.  Learn how to craft controllers that will win the respect of your friends and neighbors.",
                       CreatorName = "Jane Doe",
                       Duration = 4,
                       Level = "Intermediate",
                       Name = "Well behaved controllers",
                       UpVoteCount = 0
                   }
                }
            };

            return temp;
        }


    }
}