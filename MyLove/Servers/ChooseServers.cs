using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;
using Data.Repository.Implement;
using Data.Repository.Interface;
using DataContract;
using log4net;
using log4net.Core;
using Servers.Interface;

namespace Servers
{
    public  class ChooseServers:IChooseServers
    {
        public ILocationRepository locationRepository;
        public ITrackingRepository trackingRepository;
        public ILog Logger;

        public ChooseServers()
        {
            trackingRepository=new TrackingRepository();
            locationRepository=new LocationRepository();
            Logger = LogManager.GetLogger(this.GetType());
        }

        public IList<LocationData> GetLocations(int userId)
        {
            List<LocationData> locationList=new List<LocationData>();


            var result = locationRepository.GetLocations(userId);
            foreach (Location location in result)
            {
                locationList.Add(new LocationData(){Id=location.Id,AddressName = location.AddressName});
            }

            return locationList;
        }

        public bool DeleteLocation(int Id)
        {
            return locationRepository.DeleteLocation(Id);

        }

        public bool AddALocation(int userId, string addressName)
        {

            return locationRepository.AddLocation(userId, addressName);
        }
    }
}
