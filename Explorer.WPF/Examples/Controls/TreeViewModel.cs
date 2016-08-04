using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Explorer.WPF.Examples.Controls
{
    public class TreeViewModel : ViewModelBase 
    {
        public ObservableCollection<NodeItem> Items { get; set; } 

        // We would inject something in here so that the treeviewmodel can use it to fill up the items
        public TreeViewModel()
        {
            var myCol = new ObservableCollection<NodeItem>();
            myCol.Add(new NodeItem {Name = "Dir1"});
            myCol.Add(new NodeItem {Name = "Dir2"});
            var myNodeItem3 = new NodeItem();
            myNodeItem3.Name = "Dir3";
            var myCol2 = new ObservableCollection<NodeItem>();
            myCol2.Add(new NodeItem{Name = "File1"});
            myCol2.Add(new NodeItem { Name = "File3" });
            myCol2.Add(new NodeItem { Name = "Filef" });
            myNodeItem3.Children = myCol2;
            myCol.Add(myNodeItem3);

            Items = myCol;

        }
    }
}
