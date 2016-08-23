using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Threading;

namespace Explorer.Test.Async
{
    [TestClass]
    public class AsyncAwaitTests
    {
        // In asynchronous programming, the async method can have three possible return types. These are void, Task, Task<Result>

        [TestMethod]
        public void AsyncAwaitTest1()
        {
            btnCallMethod_Click();
            Console.WriteLine("Callback has been called");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("I have slept 1 second");
        }

        // Async void is typically used on event methods, this is where you don't wait for the return from the method
        public async void btnCallMethod_Click()
        {
            await Task.Run(() => { Thread.Sleep(2000); });
            Console.WriteLine("Done with first task!");

            await Task.Run(() => { Thread.Sleep(2000); });
            Console.WriteLine("Done with second task!");

            await Task.Run(() => { Thread.Sleep(2000); });
            Console.WriteLine("Done with third task!");


        }
    }
}
