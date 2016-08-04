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
    public class IAsyncResultTests
    {
        [TestMethod]
        public void Asynchronous_Delegate_Invocation_Calls_CallBack_When_Finished()
        {
            var _complete = new ManualResetEvent(false);

            Func<string, int> method = (s) => { System.Threading.Thread.Sleep(1000); return s.Length; };
            IAsyncResult asyncResult = method.BeginInvoke("test", (IAsyncResult result) =>
            {
                _complete.Set();
                var target = (Func<string, int>)result.AsyncState;
                var answer = target.EndInvoke(result);
            }, method);

            // eek this doesn't wait for the call back to finish
            while (!asyncResult.AsyncWaitHandle.WaitOne(Timeout.Infinite))
            {
            }

            // so we have to use a manual reset event
            _complete.WaitOne();
        }

        [TestMethod]
        public void Asynchronous_Delegate_Invocation_Does_Not_Go_Bust_On_Exception()
        {
            var _complete = new ManualResetEvent(false);
            Func<string, int> method = (s) =>
            {
                System.Threading.Thread.Sleep(1000);
                throw null;
            };

            IAsyncResult asyncResult = method.BeginInvoke("test", (result) =>
            {
                _complete.Set();
            }, method);

            _complete.WaitOne();
        }

        [TestMethod]
        public void Asynchronous_Delegate_Invocation_Exception_Propagates_Successfully()
        {
            var _complete = new ManualResetEvent(false);
            Func<string, int> method = (s) =>
            {
                System.Threading.Thread.Sleep(1000);
                throw null;
            };

            IAsyncResult asyncResult = method.BeginInvoke("test", (result) =>
            {
                try
                {
                    var target = (Func<string, int>)result.AsyncState;
                    var answer = target.EndInvoke(result);
                }
                catch (NullReferenceException)
                {
                    _complete.Set();
                }

            }, method);

            _complete.WaitOne();
        }
    }
}
