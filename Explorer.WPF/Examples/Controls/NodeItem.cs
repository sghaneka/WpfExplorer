using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.WPF.Examples.Controls
{
    public class NodeItem
    {
        public string Name { get; set; }

        public ObservableCollection<NodeItem> Children { get; set; }
    }
}
