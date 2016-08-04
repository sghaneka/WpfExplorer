using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Explorer.Console.Async
{
    public static class TaskDemo
    {
        public static void TaskTest1()
        {
            var web = new WebClient();
            System.Console.WriteLine("Starting work");
            Task<string> getTask = web.DownloadStringTaskAsync("http://wpf/Jaju/LongRunningRequestWithError?sleepTime=3000");
            System.Console.WriteLine("Setting up continuation");
            getTask.ContinueWith(t =>
            {
                System.Console.WriteLine(t.IsFaulted);
                System.Console.WriteLine(t.Exception);
                System.Console.WriteLine("In continuation");
                System.Console.WriteLine(t.Result);
            });
            System.Console.WriteLine("Continuing on main thread");
            System.Console.ReadLine();
            GC.Collect();
            Thread.Sleep(10000);
            System.Console.WriteLine("Completed.....");
        }

        public static async Task DoWorkAsync(int parameter)
        {
            await Task.Delay(parameter);
            System.Console.WriteLine("Awaited the delayed time");
        }

        public static async Task<double> GetNumberAsync()
        {
            var generator = new Random();
            await Task.Delay(generator.Next(1000));
            return generator.NextDouble()*1000.0;
        }

        public static async Task<Double> GetSumAsync()
        {
            var leftOperand = await GetNumberAsync();
            var rightOperand = await GetNumberAsync(); 
            return leftOperand + rightOperand;
        }

        public static async Task<double> GetProductOfSumsAsync()
        {
            var leftTask = GetSumAsync();
            var rightTask = GetSumAsync();
            return await leftTask*await rightTask;
        }
    }
}
