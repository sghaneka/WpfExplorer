using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Explorer.WPF.Examples.Events
{
    /// <summary>
    /// Interaction logic for DirectWiringVsICommand.xaml
    /// </summary>
    public partial class DirectWiringVsICommand : Window
    {
        public DirectWiringVsICommand()
        {
            InitializeComponent();
        }

        private void btnDirect_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Directly wired...");
        }
    }
}
