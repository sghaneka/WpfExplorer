using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Explorer.WPF.Examples.Events
{
    public class MainWindowViewModel
    {
        public MyCommand ShowMessageCommand { get; set; }

        public MainWindowViewModel()
        {
            ShowMessageCommand = new MyCommand(() => MessageBox.Show("from the command..."));
        }
    }
}
