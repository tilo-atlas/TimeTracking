using System;
using System.Collections.Generic;

namespace TimeTrackingLib
{
    public interface ITimeTracking : IDisposable
    {
        IEnumerable<ITimeAccount> Accounts { get; }

        ITrackingSession CurrentSession { get; }

        event Action TimeAccountListChanged;

        void AddAccount(string name);

        bool SwitchAccount(ITimeAccount account);
    }
}