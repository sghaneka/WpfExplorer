using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Utils.Attributes
{
    public class ValueMapAttribute : Attribute
    {
        public string ActualValue { get; set; }
        public ValueMapAttribute(string actualValue)
        {
            ActualValue = actualValue;
        }
    }
}
