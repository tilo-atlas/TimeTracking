using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TimeTrackingLib
{
    public class TrackingSession : ITrackingSession
    {
        public DateTime Start { get; }

        public DateTime? End { get; set; }

        public Guid ID { get; } = Guid.NewGuid();

        [JsonIgnore]
        public ITimeAccount Account { get; internal set; }

        [JsonProperty]
        internal readonly Guid _accountID;

        public IList<string> Comments { get; private set; } = new List<string>();

        [JsonIgnore]
        public TimeSpan Duration => (End.HasValue ? End.Value : DateTime.Now) - Start;

        internal TrackingSession(ITimeAccount account) : this(account, DateTime.Now) { }

        internal TrackingSession(ITimeAccount account, DateTime start)
        {
            Start = start;
            Account = account;
            _accountID = account.ID;
        }
    }
}
