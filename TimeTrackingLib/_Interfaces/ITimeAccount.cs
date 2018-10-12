using System;

namespace TimeTrackingLib
{
    public interface ITimeAccount
    {
        Guid ID { get; }

        string Name { get; }

        DateTime Created { get; }

        DateTime? Archived { get; set; }
    }
}