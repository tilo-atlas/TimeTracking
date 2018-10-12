using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackingLib
{
    internal interface IStore<T>
    {
        IList<T> Load();
        void Save(IList<T> items);
    }
}
