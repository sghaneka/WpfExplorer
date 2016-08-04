using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Explorer.Test.Async
{
    [TestClass]
    public class ThreadingTests
    {
        //[TestMethod]
        public void ThreadException_Does_Not_PropogateToCreator_And_Tears_Down_Everything()
        {
            try
            {
                new Thread(Go).Start();
            }
            catch (ApplicationException)
            {
                Assert.Fail("Better not get here...");
            }
           
        }

        [TestMethod]
        public void ProperThreadExceptionHandling()
        {
            var thread = new Thread(ProperGo);
            thread.Start();
            thread.Join();
            // All should be good, as exception is handled in the thread.
        }

        public void Go() { throw new ApplicationException(); }

        public void ProperGo()
        {
            try
            {
                throw null;
            }catch (NullReferenceException)
            {

            }
        }

        [TestMethod]
        public void Captured_Variables_Should_Not_Be_Changed_After_Passing_To_A_Thread()
        {
            List<int> temp = new List<int>();
            List<Thread> threads = new List<Thread>();
            for(int i=0; i<10; i++)
            {
                Thread nova = new Thread(() => { temp.Add(i); });
                nova.Start();
                threads.Add(nova);
            }
            foreach (var thread in threads)
                thread.Join();
            // This will never really contain 0 to 9
            int totalIn = 0;
            for (int i=0; i<10; i++)
            {
                if (temp.Contains(i))
                    totalIn++;
            }
            Assert.AreNotEqual(totalIn, 10);
        }

        [TestMethod]
        public void Proper_Use_Of_Captured_Variables()
        {
            List<int> temp = new List<int>();
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 10; i++)
            {
                int tmpHolder = i;
                Thread nova = new Thread(() => { temp.Add(tmpHolder); });
                nova.Start();
                threads.Add(nova);
            }

            foreach (var thread in threads)
                thread.Join();

            // This will now contain 0 to 9
            int totalIn = 0;
            for (int i = 0; i < 10; i++)
            {
                if (temp.Contains(i))
                    totalIn++;
            }
            Assert.AreEqual(totalIn, 10);
        }



    }
}
