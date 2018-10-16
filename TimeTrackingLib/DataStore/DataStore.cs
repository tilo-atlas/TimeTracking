using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace TimeTrackingLib
{
    internal class DataStore : IDataStore
    {
        private string _json = string.Empty;
        private readonly string _dataFileName;

        public DataStore() : this(string.Empty) { }

        public DataStore(string path)
        {
            _dataFileName = path;
        }

        public IList<T> Read<T>()
        {
            string json = _json;
            if (!string.IsNullOrEmpty(_dataFileName) && File.Exists(_dataFileName))
            {
                json = File.ReadAllText(_dataFileName);
            }

            if (!string.IsNullOrEmpty(json))
            {
                return JsonConvert.DeserializeObject<T[]>(json);
            }
            return new List<T>();
        }

        public void Write(object data)
        {
            _json = JsonConvert.SerializeObject(data, Formatting.Indented);
            if (!string.IsNullOrEmpty(_dataFileName))
            {
                File.WriteAllText(_dataFileName, _json);
            }
        }
    }
}
