using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TimeTrackingLib.Tests
{
    [TestClass()]
    public class TimeTrackingTests
    {
        [TestMethod]
        public void TimeTracking_Initial_State()
        {
            var tt = new TimeTracking();

            // break account
            Assert.IsTrue(tt.Accounts.Active.Count() == 1);
            Assert.IsTrue(tt.Accounts.Break is BreakAccount);
            Assert.IsTrue(tt.Accounts.Active.First() is BreakAccount);

            // session
            Assert.IsNotNull(tt.CurrentSession);
            Assert.IsTrue(tt.CurrentSession.Account is BreakAccount);
        }

        [TestMethod]
        public void TimeTracking_Dispose()
        {
            var tt = new TimeTracking();
            tt.Dispose();

            Assert.IsNull(tt.CurrentSession);
        }

        [TestMethod]
        public void TimeTracking_AddAccount()
        {
            const string TestAccountName = "Test1";
            var tt = new TimeTracking();
            tt.AddAccount(TestAccountName);

            Assert.IsTrue(tt.Accounts.Active.Count() == 2);

            // break account
            Assert.IsTrue(tt.Accounts.Break is BreakAccount);
            Assert.IsTrue(tt.Accounts.Active.First() is BreakAccount);

            // session
            Assert.IsNotNull(tt.CurrentSession);
            Assert.IsTrue(tt.CurrentSession.Account is BreakAccount);

            // new account
            Assert.AreEqual(tt.Accounts.Active.ElementAt(1).Name, TestAccountName, false);
        }

        [TestMethod]
        public void TimeTracking_Switch()
        {
            const string TestAccountName = "Test1";
            var tt = new TimeTracking();
            ITimeAccount newAccount = tt.AddAccount(TestAccountName);
            tt.Switch(newAccount);

            Assert.AreSame(tt.CurrentSession.Account, newAccount);
            
        }
    }
}