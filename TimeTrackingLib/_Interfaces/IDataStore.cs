using System.Collections.Generic;

namespace TimeTrackingLib
{
    internal interface IDataStore
    {
        IList<T> Read<T>();

        void Write(object data);
    }
}
