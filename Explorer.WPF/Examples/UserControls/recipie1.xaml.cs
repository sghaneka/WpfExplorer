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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Explorer.WPF.Examples.UserControls.Controls;

namespace Explorer.WPF.Examples.UserControls
{
    /// <summary>
    /// Interaction logic for recipie1.xaml
    /// </summary>
    public partial class recipie1 : Window
    {
        public recipie1()
        {
            InitializeComponent();
        }

        private void CurrentDecButton_Click(object sender, RoutedEventArgs e)
        {
            pager.Current--;
        }

        private void CurrentIncButton_Click(object sender, RoutedEventArgs e)
        {
            pager.Current++;
        }

        private void TotalDecButton_Click(object sender, RoutedEventArgs e)
        {
            pager.Total--;
        }

        private void TotalIncButton_Click(object sender, RoutedEventArgs e)
        {
            pager.Total++;
        }

        private void SearchControl_SearchChanged(object sender, SearchControl.SearchChangedEventArgs e)
        {
            MessageBox.Show("New Search: " + e.SearchText);
        }
    }
}
