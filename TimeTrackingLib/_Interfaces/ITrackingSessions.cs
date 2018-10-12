using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackingLib
{
    public interface ITrackingSessions
    {
        void Add(ITrackingSession session);
    }
}
