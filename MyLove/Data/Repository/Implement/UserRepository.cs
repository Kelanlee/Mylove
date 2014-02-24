using System;
using System.Linq;
using Data.Models;
using Data.Repository.Interface;
using log4net;
namespace Data.Repository.Implement
{
    public class UserRepository:BaseRepository,IUserRepository
    {

        public ILog Logger;
        public UserRepository()
        {
            Logger = LogManager.GetLogger(this.GetType());
        }

        public User getUserByUsername(string username)
        {
            Logger.Info("UserRepository-getUserByUsername:Username="+username);
            if (string.IsNullOrEmpty(username))
            {
                Logger.Info("UserRepository-getUserByUsername:username is null or empty.");
                return null;
            }
            try
            {
                var users = from u in DB.Users where u.Username == username select u;
                Logger.Info("UserRepository-getUserByUsername:Find "+users.Count()+" users");
                return users.FirstOrDefault();
            }
            catch (Exception e)
            {
                Logger.Error("UserRepository-getUserByUsername:Error:"+e);
                return null;
            }
            


        }

        public User getUserByUserId(int userId)
        {
            Logger.Info("UserRepository-getUserByUserId:UserId=" + userId);
            if (userId == null||userId==0    )
            {
                Logger.Info("UserRepository-getUserByUserId:userId is null or 0.");
                return null;
            }
            try
            {
                var users = from u in DB.Users where u.UserId == userId select u;
                Logger.Info("UserRepository-getUserByUsername:Find " + users.Count() + " users");
                return users.FirstOrDefault();
            }
            catch (Exception e)
            {
                Logger.Error("UserRepository-getUserByUserId:Error:" + e);
                return null;
            }
        }
    }
}
