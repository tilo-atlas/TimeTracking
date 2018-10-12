using System;

namespace TimeTrackingLib
{
    public class BreakAccount : ITimeAccount
    {
        public Guid ID => new Guid("f05b63b8-e179-4f6e-af3a-896323ceb6e0");

        public string Name { get => "Break"; }

        public DateTime Created => DateTime.MinValue;

        public DateTime? Archived { get => null; set => throw new ApplicationException("break account cannot be archived"); }

        internal BreakAccount() { }
    }
}
