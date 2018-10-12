using Newtonsoft.Json;
using System;

namespace TimeTrackingLib
{
    public class TimeAccount : ITimeAccount
    {
        public Guid ID { get; }

        public string Name { get; }

        public DateTime Created { get; } = DateTime.Now;

        public DateTime? Archived { get; set; }

        public TimeAccount(string name)
        {
            Name = name;
            ID =  Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is TimeAccount)
            {
                var ta = obj as TimeAccount;
                return ta.ID.Equals(ID);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
