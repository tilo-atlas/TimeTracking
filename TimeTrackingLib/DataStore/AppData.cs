using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TimeTrackingLib
{
    public class AppData : IAppData
    {
        private IDataStore _sessionStore = new DataStore();
        private IDataStore _accountStore = new DataStore();

        private IList<ITimeAccount> _accounts;

        public TimeAccounts Accounts { get; }

        public AppData(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                _sessionStore = new DataStore(Path.Combine(path, $"tts.{DateTime.Now.Year}.db"));
                _accountStore = new DataStore(Path.Combine(path, "tta.db"));
            }
            _accounts = new List<ITimeAccount>(_accountStore.Read<TimeAccount>());
            _accounts.Insert(0, new BreakAccount());
            Accounts = new TimeAccounts(_accounts);
        }

        public void AddSession(ITrackingSession session)
        {
            if (!session.End.HasValue)
            {
                session.End = DateTime.Now;
            }

            var sessions = new List<ITrackingSession>(_sessionStore.Read<TrackingSession>());
            sessions.Add(session);
            _sessionStore.Write(sessions);
        }

        public ITimeAccount AddAccount(string name)
        {
            ITimeAccount result = null;
            // account name could be already existing
            var account = _accounts.FirstOrDefault(a => a.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
            if (account != null)
            {
                // yes account already exists
                if (account.Archived.HasValue)
                {
                    // reactivate
                    account.Archived = null;
                    result = account;
                }
            }
            else
            {
                // create new one
                result = new TimeAccount(name);
                _accounts.Add(result);
                
            }

            if (result != null)
            {
                _accountStore.Write(_accounts);
            }

            return result;
        }
    }
}
