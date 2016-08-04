using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Explorer.WPF.Examples.Async
{
    /// <summary>
    /// Interaction logic for AsyncDemo.xaml
    /// </summary>
    public partial class AsyncDemo : Window
    {
        public AsyncDemo()
        {
            InitializeComponent();
            Results.Text = "";
        }

        // Simple use of a thread
        private void btnThread1_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(() => Dispatcher.InvokeAsync(() => Results.Text += "This will work"));
            t.Start();
        }

        private void btnThreadPassingData_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(() => Print("Passing data along!"));
            t.Start();
        }

        private void btnThreadCapturing_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            PrintLine("ThreadCapturing.....");
            for(int i =0; i< 10; i++)
            {
                new Thread(() => PrintLine(i.ToString())).Start();
            }
            PrintLine("Note it's non deterministic, since i is not being captured...");
            PrintLine("Now fixing...");
            for (int i = 0; i < 10; i++)
            {
                int temp = i;
                new Thread(() => PrintLine(temp.ToString())).Start();
            }
            PrintLine("Much better.... ");
        }

        private void btnThreadException_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new Thread(Go).Start();
            }
            catch (Exception ex)
            {
                PrintLine("This will never get called!");
            }
        }

        private void Go()
        {
            throw null;
        }

        private void Print(string message)
        {
            int managedThreadId = Thread.CurrentThread.ManagedThreadId;
            Dispatcher.InvokeAsync(() => Results.Text += "ThreadID: " + managedThreadId + " " + message);
        }

        private void PrintLine(string message)
        {
            int managedThreadId = Thread.CurrentThread.ManagedThreadId;
            Dispatcher.InvokeAsync(() => Results.Text += "ThreadID: " + managedThreadId + " " + message + System.Environment.NewLine );
        }

        private void Clear()
        {
            Dispatcher.InvokeAsync(() => Results.Text = String.Empty);
        }


        private void AppendResults(string message)
        {
            Results.Text += message;
        }
    }
}
