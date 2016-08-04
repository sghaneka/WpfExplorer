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
using Explorer.WPF.Examples.MVVM_ViewServices.Services;
using Explorer.WPF.Examples.MVVM_ViewServices.ViewModels;

namespace Explorer.WPF.Examples.MVVM_ViewServices.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl, IDialogService
    {
        public MainView()
        {
            InitializeComponent();
        }

        public bool Prompt(string message)
        {
            return MessageBox.Show(
                message,
                "View Services",
                MessageBoxButton.YesNo) ==
                MessageBoxResult.Yes;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //
            // XAML Patterns (4.9):
            //
            // Register as providing the dialog service with the IoC container
            // through the view model locator.
            //
            ViewModelLocator.Current.Register<IDialogService>(this);
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            //
            // XAML Patterns (4.9):
            //
            // Clean up after yourself.
            //
            ViewModelLocator.Current.Unregister<IDialogService>();
        }
    }
}
