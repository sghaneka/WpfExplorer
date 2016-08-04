using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Explorer.WPF.Examples.MVVM_MessageBus.Messages
{
    public class SessionTitleChanged
    {
        public int SessionId { get; set; }
        public string NewTitle { get; set; }
    }
}
