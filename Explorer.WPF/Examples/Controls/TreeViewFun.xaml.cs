using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Explorer.WPF.Examples.Controls
{
    /// <summary>
    /// Interaction logic for TreeView.xaml
    /// </summary>
    public partial class TreeViewFun : Window
    {
        public TreeViewFun()
        {
            InitializeComponent();
            dirTree.AddHandler(TreeViewItem.ExpandedEvent,
                new RoutedEventHandler(OnTreeItemExpanded));
        }

        private void OnTreeItemExpanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.OriginalSource as TreeViewItem;
            
            MessageBox.Show("Expanded");
        }

        
    }
}
