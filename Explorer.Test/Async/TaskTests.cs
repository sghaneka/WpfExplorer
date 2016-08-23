using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Explorer.Test.Async
{
    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public void SimpleTaskTest1()
        {
            var web = new WebClient();
            Console.WriteLine("Starting work");
            // Task<string> getTask = web.DownloadStringTaskAsync("http://wpf/Jaju/LongRunningRequestWithError?sleepTime=3000");

            Task<string> task1 = Task.Run(() =>
            {
                System.Threading.Thread.Sleep(3000);
                return "result";
            });


            Console.WriteLine("Setting up continuation");

            task1.ContinueWith(t =>
            {
                Console.WriteLine("In continuation");
                Console.WriteLine(t.IsFaulted);
                Console.WriteLine(t.Exception);
                Console.WriteLine(t.Result);
            });

            Console.WriteLine("Continuing on main thread");
            GC.Collect();
            Thread.Sleep(10000);
            Console.WriteLine("Completed.....");
        }
    }
}
