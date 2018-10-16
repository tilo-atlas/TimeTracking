﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackingLib
{
    public interface ITimeAccounts
    {
        ITimeAccount Break { get; }

        IEnumerable<ITimeAccount> Active { get; }
    }
}
