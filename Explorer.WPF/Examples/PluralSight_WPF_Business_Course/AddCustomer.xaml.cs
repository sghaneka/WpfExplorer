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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;

namespace Explorer.WPF.Examples.PluralSight_WPF_Business_Course
{
    /// <summary>
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Window
    {
        public AddCustomer()
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, CloseMessageReceived);
        }

        private void CloseMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "Close")
            {
                this.Close();
            }
        }
    }
}
