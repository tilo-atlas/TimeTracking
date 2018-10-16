using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackingLib
{
    internal interface IAppData
    {
        TimeAccounts Accounts { get; }

        void AddSession(ITrackingSession session);

        ITimeAccount AddAccount(string name);
    }
}
