using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace TimeTrackingLib
{
    internal class TrackingSessions : ITrackingSessions
    {
        const int MinimalTrackingMinutes = 0;

        private readonly string _dataFileName = $"tts.{DateTime.Now.Year}.db";

        private static readonly ITrackingSessions _store = new TrackingSessions();

        public static ITrackingSessions Store => _store;

        private TrackingSessions() { }

        public void Add(ITrackingSession session)
        {
            Trace.Assert(session != null);

            session.End = DateTime.Now;
            if (!(session.Account is BreakAccount) && session.Duration.Minutes >= MinimalTrackingMinutes)
            {
                IList<ITrackingSession> store = ReadStore();
                store.Add(session);
                File.WriteAllText(_dataFileName, JsonConvert.SerializeObject(store, Formatting.Indented));
            }
        }

        private IList<ITrackingSession> ReadStore()
        {
            if (File.Exists(_dataFileName))
            {
                string json = File.ReadAllText(_dataFileName);
                return new List<ITrackingSession>(JsonConvert.DeserializeObject<TrackingSession[]>(json));
            }
            return new List<ITrackingSession>();
        }
    }
}
