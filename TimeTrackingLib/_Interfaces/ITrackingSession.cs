using System;
using System.Collections.Generic;

namespace TimeTrackingLib
{
    public interface ITrackingSession
    {
        DateTime Start { get; }

        DateTime? End { get; set; }

        ITimeAccount Account { get; }

        Guid ID { get; }

        IList<string> Comments { get; }

        TimeSpan Duration { get; }
    }
}