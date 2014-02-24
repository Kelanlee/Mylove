using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;
using Data.Repository.Interface;
using log4net;

namespace Data.Repository.Implement
{
    public class LocationRepository:BaseRepository,ILocationRepository
    {
        public ILog Logger;
        public LocationRepository()
        {
            Logger = LogManager.GetLogger(this.GetType());
        }


        public IList<Location> GetLocations(int userId)
        {
            Logger.Info("LocationRepository-GetLocations:UserId=" + userId);
            if (userId<1)
            {
                Logger.Info("LocationRepository-GetLocations:UserId is wrong.");
                return null;
            }
            try
            {
                List<Location> result=new List<Location>();
                var locations = DB.Locations.Where(t => t.UserId == userId);
                Logger.Info("LocationRepository-GetLocations:Find " + locations.Count() + " locations");
                if (!locations.Any())
                {
                    return result;
                }
                foreach (var location in locations)
                {
                    result.Add(location);

                }
                return result;
            }
            catch (Exception e)
            {
                Logger.Error("LocationRepository-GetLocations:Error:" + e);
                return null;
            }
        }

        public bool DeleteLocation(int Id)
        {
            Logger.Info("LocationRepository-DeleteLocation:UserId=" + Id);
            if (Id < 1 )
            {
                Logger.Info("LocationRepository-DeleteLocation:info is wrong.");
                return false;
            }
            try
            {
                var tempDelete = DB.Locations.FirstOrDefault(t => t.Id == Id);
                DB.Locations.Remove(tempDelete);
                var count = DB.SaveChanges();

                if (count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Logger.Error("LocationRepository-DeleteLocation:Error:" + e);
                return false;
            }
        }

        public bool AddLocation(int userId, string addressName)
        {
            try
            {
                Location temp = new Location() { AddressName = addressName, UserId = userId };

                DB.Locations.Add(temp);
                var count = DB.SaveChanges();
                return count > 0 ? true : false;
            }
            catch (Exception e)
            {
                Logger.Error("LocationRepository-AddLocation:Error:" + e);
                throw;
            }
            
        }

        
    }
}
