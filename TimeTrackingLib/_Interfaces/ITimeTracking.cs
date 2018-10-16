using System;

namespace TimeTrackingLib
{
    public interface ITimeTracking : IDisposable
    {
        ITimeAccounts Accounts { get; }

        ITrackingSession CurrentSession { get; }

        event Action TimeAccountListChanged;

        ITimeAccount AddAccount(string name);

        bool Switch(ITimeAccount account);
    }
}