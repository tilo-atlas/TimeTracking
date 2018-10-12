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
        public ITimeAccount Account
        {
            get
            {
                return TimeAccounts.Store.GetByID(_accountID);
            }
        }

        [JsonProperty]
        private readonly Guid _accountID;

        public IList<string> Comments { get; private set; } = new List<string>();

        [JsonIgnore]
        public TimeSpan Duration => (End.HasValue ? End.Value : DateTime.Now) - Start;

        public TrackingSession() { }

        public TrackingSession(ITimeAccount account) : this(account, DateTime.Now) { }

        public TrackingSession(ITimeAccount account, DateTime start)
        {
            Start = start;
            _accountID = account.ID;
        }
    }
}
