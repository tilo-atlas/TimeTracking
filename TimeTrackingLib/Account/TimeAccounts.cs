using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TimeTrackingLib
{
    internal sealed class TimeAccounts : ITimeAccounts
    {
        private readonly string _dataFileName = "tta.db";

        private static readonly ITimeAccounts _singleton = new TimeAccounts();
        internal static ITimeAccounts Store => _singleton;

        private readonly IList<ITimeAccount> _accounts = null;

        public IEnumerable<ITimeAccount> Active
        {
            get
            {
                return _accounts.Where(a => !a.Archived.HasValue);
            }
        }

        public IEnumerable<ITimeAccount> Archived
        {
            get
            {
                return _accounts.Where(a => a.Archived.HasValue);
            }
        }

        private TimeAccounts()
        {
            _accounts = ReadStore();
        }

        public bool Add(string name)
        {
            bool result = false;
            // account name could be already existing
            var account = _accounts.FirstOrDefault(a => a.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
            if (account != null)
            {
                // yes account already exists
                if (account.Archived.HasValue)
                {
                    // reactivate
                    account.Archived = null;
                    result = true;
                }
            }
            else
            {
                // create new one
                _accounts.Add(new TimeAccount(name));
                result = true;
            }

            if (result)
            {
                File.WriteAllText(_dataFileName, JsonConvert.SerializeObject(_accounts.Skip(1).ToArray(), Formatting.Indented));
            }

            return result;
        }

        public ITimeAccount GetByID(Guid id)
        {
            return _accounts.FirstOrDefault(a => a.ID.Equals(id));
        }

        private IList<ITimeAccount> ReadStore()
        {
            var list = new List<ITimeAccount>();
            list.Add(new BreakAccount());
            if (File.Exists(_dataFileName))
            {
                string json = File.ReadAllText(_dataFileName);
                list.AddRange(JsonConvert.DeserializeObject<TimeAccount[]>(json));
                return list;
            }
            return list;
        }
    }
}