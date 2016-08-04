using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Explorer.Test.Async
{
    [TestClass]
    public class BackgroundWorkerTests
    {
        private BackgroundWorker _bw;
        private ManualResetEvent _mer;

        public class TestInputs
        {
            public string Name { get; set; }
            public int AccountNumber { get; set; }
        }

        [TestInitialize]
        public void Init()
        {
            _bw = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            _mer = new ManualResetEvent(false);
        }

        [TestMethod]
        public void BW_Calls_Do_Work_With_Correct_Inputs()
        {
            _bw.DoWork += (sender, e) =>
            {
                TestInputs t = (TestInputs)e.Argument;
                Assert.AreEqual("Jaju", t.Name);
                Assert.AreEqual(8320234, t.AccountNumber);
                _mer.Set();
            };
            _bw.RunWorkerAsync(new TestInputs { Name = "Jaju", AccountNumber = 8320234 });
            _mer.WaitOne();
        }

        [TestMethod]
        public void BW_Progress_Changed_Fires_Correctly()
        {
            List<int> progress = new List<int>();
            _bw.DoWork += (sender, e) =>
            {
                TestInputs t = (TestInputs)e.Argument;
                for(int i =0; i<=100; i += 20)
                {
                    _bw.ReportProgress(i);
                    Thread.Sleep(350);
                }
                _mer.Set();
            };

            _bw.ProgressChanged += (sender, e) =>
            {
                progress.Add(e.ProgressPercentage);
            };

            _bw.RunWorkerAsync(new TestInputs { Name = "Jaju", AccountNumber = 8320234 });
           
            _mer.WaitOne();
            Assert.IsTrue(progress.SequenceEqual(new int[] { 0, 20, 40, 60, 80, 100 }));
        }

        [TestMethod]
        public void BW_Captures_Result_After_Worker_Completes_Correctly()
        {
            int result = 0;
            _bw.DoWork += (sender, e) =>
            {
                TestInputs t = (TestInputs)e.Argument;
                e.Result = 1024;
            };

            _bw.RunWorkerCompleted += (sender, e) => {
                result = (int) e.Result;
                _mer.Set();
            };

            _bw.RunWorkerAsync(new TestInputs { Name = "Jaju", AccountNumber = 8320234 });
            _mer.WaitOne();
            Assert.AreEqual(result, 1024);
        }

        [TestMethod]
        public void BW_Captures_Exception_Correctly()
        {
            int result = 0;
            Exception tempEx = null;
            _bw.DoWork += (sender, e) =>
            {
                TestInputs t = (TestInputs)e.Argument;
                e.Result = 1024;
                throw null;
            };

            _bw.RunWorkerCompleted += (sender, e) => {
                tempEx = e.Error;
                _mer.Set();
            };

            _bw.RunWorkerAsync(new TestInputs { Name = "Jaju", AccountNumber = 8320234 });
            _mer.WaitOne();
            Assert.IsInstanceOfType(tempEx, typeof(NullReferenceException));
        }

        [TestMethod]
        public void BW_Propgates_Cancellation_Correctly()
        {
            bool isCancelled = false;
            _bw.DoWork += (sender, e) =>
            {
                TestInputs t = (TestInputs)e.Argument;
                for (int i = 0; i <= 100; i += 20)
                {
                    if (_bw.CancellationPending) { e.Cancel = true; return; }
                    Thread.Sleep(350);
                }
            };

            _bw.RunWorkerCompleted += (sender, e) => {
                isCancelled = e.Cancelled;
                _mer.Set();
            };

            _bw.RunWorkerAsync(new TestInputs { Name = "Jaju", AccountNumber = 8320234 });
            _bw.CancelAsync();
            _mer.WaitOne();
            Assert.IsTrue(isCancelled);
        }



    }
}
