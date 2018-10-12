using System;
using System.Collections.Generic;

namespace TimeTrackingLib
{
    public interface ITimeAccounts
    {
        IEnumerable<ITimeAccount> Active { get; }

        IEnumerable<ITimeAccount> Archived { get; }

        bool Add(string name);

        ITimeAccount GetByID(Guid id);
    }
}
