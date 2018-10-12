using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeTrackingLib
{
    public class TimeTracking : ITimeTracking
    {
        public IEnumerable<ITimeAccount> Accounts => TimeAccounts.Store.Active;

        public event Action TimeAccountListChanged;

        public ITrackingSession CurrentSession { get; private set; }

        public TimeTracking(string dataPath)
        {
            CurrentSession = new TrackingSession(Accounts.First() /* Break */);
        }

        public bool SwitchAccount(ITimeAccount account)
        {
            if (account.Equals(CurrentSession.Account))
            {
                return false; // if same account then continue with same session
            }

            TrackingSessions.Store.Add(CurrentSession);
            CurrentSession = new TrackingSession(account);
            return true;
        }

        public void AddAccount(string name)
        {
            if (!string.IsNullOrEmpty(name) && TimeAccounts.Store.Add(name))
            {
                TimeAccountListChanged?.Invoke();
            }
        }

        public void Dispose()
        {
            TrackingSessions.Store.Add(CurrentSession);
            CurrentSession = null;
        }
    }
}
