using System;

namespace TimeTrackingLib
{
    public class TimeTracking : ITimeTracking
    {
        private IAppData _data;

        public ITimeAccounts Accounts { get => _data.Accounts; }

        public event Action TimeAccountListChanged;

        public ITrackingSession CurrentSession { get; private set; }

        public TimeTracking() : this(null) { }

        public TimeTracking(string dataPath)
        {
            _data = new AppData(dataPath);
            CurrentSession = new TrackingSession(_data.Accounts.Break);
        }

        public bool Switch(ITimeAccount account)
        {
            if (account.Equals(CurrentSession.Account))
            {
                return false; // if same account then continue with same session
            }
            _data.AddSession(CurrentSession);
            CurrentSession = new TrackingSession(account);
            return true;
        }

        public ITimeAccount AddAccount(string name)
        {
            ITimeAccount result = null;
            if (!string.IsNullOrEmpty(name))
            {
                result = _data.AddAccount(name);
                if (result != null)
                    TimeAccountListChanged?.Invoke();
            }
            return result;
        }

        public void Dispose()
        {
            _data.AddSession(CurrentSession);
            CurrentSession = null;
        }
    }
}
