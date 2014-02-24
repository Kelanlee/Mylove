using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;
using Data.Repository.Implement;
using Data.Repository.Interface;
using DataContract;
using log4net;
using Servers.Interface;

namespace Servers
{
    public class HomeServers:IHomeServers
    {
        public IUserRepository userRepository;
        public ITrackingRepository trackingRepository;
        private ILog Logger;
        public HomeServers()
        {
            Logger = LogManager.GetLogger(this.GetType());
            userRepository = new UserRepository();
            trackingRepository = new TrackingRepository();
        }

        public List<TrackingData> GetTracking(int userId)
        {
            var user=userRepository.getUserByUserId(userId);
            var temp = trackingRepository.Get3Tracking((int) user.Relationship);
            List<TrackingData> result = new List<TrackingData>();
            if (!temp.Any())
            {
                return result;
            }

            foreach (Tracking tracking in temp)
            {
                result.Add(new TrackingData(){TrackingName = tracking.Tracking1,TrackingTime = tracking.TrackingTime});
            }
            return result;
        }
    }
}
