using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;

namespace MiscTest
{
    [TestClass]
    public class SerilogTest
    {
        [TestMethod]
        public void TestLog()
        {
            ILogger log = Log.ForContext<SerilogTest>();
            log.Information("Test");

            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void TestPushProperty()
        {
            Serilog.Context.LogContext.Suspend();

            ILogger log = Log.ForContext<SerilogTest>();
            using (Serilog.Context.LogContext.PushProperty("Test property", "Test value"))
            {
                log.Information("Test");
            }

            Assert.AreEqual(1, 1);
        }
    }
}
