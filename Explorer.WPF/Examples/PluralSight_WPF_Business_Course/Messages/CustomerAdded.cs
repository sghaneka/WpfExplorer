using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.WPF.Examples.PluralSight_WPF_Business_Course.Messages
{
    public class CustomerAdded
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public string EmailAddress { get; set; }
    }
}
