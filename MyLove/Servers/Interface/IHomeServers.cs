using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataContract;

namespace Servers.Interface
{
    public  interface IHomeServers
    {
        List<TrackingData> GetTracking(int userId);
    }
}
