using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Data.Models;
using Data.Repository.Interface;
using log4net;

namespace Data.Repository.Implement
{
    public class TrackingRepository:BaseRepository,ITrackingRepository
    {
        public TrackingRepository()
        {
            Logger = LogManager.GetLogger(this.GetType());

        }

        public bool AddTracking(int userId, int trackingType, string tracking)
        {
            try
            {
                DB.Trackings.Add(new Tracking() { Tracking1 = tracking, TrackingType = trackingType, UserId = userId,TrackingTime = DateTime.Now});
                var count = DB.SaveChanges();
                if (count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public List<Tracking> Get3Tracking(int userId)
        {
            List<Tracking> result =new List<Tracking>();
            var trackings = DB.Trackings.Where(m => m.UserId == userId).OrderByDescending(m => m.id);

            int i = 0;
            if (!trackings.Any())
            {
                return result;
            }
            foreach (Tracking tracking in trackings)
            {
                i++;
                result.Add(tracking);
                if (i==3)
                {
                    break;
                }
            }

            return result;
        }
    }
}
