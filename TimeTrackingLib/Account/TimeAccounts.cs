using System.Collections.Generic;
using System.Linq;

namespace TimeTrackingLib
{
    public sealed class TimeAccounts : ITimeAccounts
    {
        private IList<ITimeAccount> _accounts;

        public ITimeAccount Break { get => _accounts.First(); }

        public IEnumerable<ITimeAccount> Active
        {
            get
            {
                return _accounts.Where(a => !a.Archived.HasValue);
            }
        }

        public TimeAccounts(IList<ITimeAccount> accounts)
        {
            _accounts = accounts;
        }

    }
}