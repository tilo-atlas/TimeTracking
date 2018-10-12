using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TimeTrackingLib.Tests
{
    [TestClass()]
    public class TimeTrackingTests
    {
        [TestMethod]
        private void Create_TimeTracking_Instance()
        {
            var instance = new TimeTracking(@"c:\temp\test");
        }
    }
}