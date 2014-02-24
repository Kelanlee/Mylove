using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;

namespace Data.Repository.Interface
{
    public interface ITrackingRepository
    {
        bool AddTracking(int userId,int trackingType,string tracking);

        List<Tracking> Get3Tracking(int userId);
    }
}
