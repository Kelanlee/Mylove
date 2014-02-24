using System;
using System.Linq;
using Data.Models;
using Data.Repository.Interface;
using log4net;
namespace Data.Repository.Implement
{
    public class MembershipRepository:BaseRepository,IMembershipRepository
    {
        
        public MembershipRepository()
        {
            Logger = LogManager.GetLogger(this.GetType());
        }

        public bool ValidatePassword(int userId, string password)
        {
            try
            {
                Logger.Info("Membership Repository - ValidatePassword:UserId="+userId+" password="+password);
                if (userId==null||userId<1)
                {
                    Logger.Info("Membership Repository - ValidatePassword:UserId is wrong.");
                    return false;
                }
                var membership = DB.MemberShips.FirstOrDefault(p => p.UserId == userId);
                Logger.Info("Membership Repository - ValidatePassword: membership.password=" + membership.Password);
                if (membership.Password == password)
                {
                    Logger.Info("Membership Repository - ValidatePassword:Password is right.");
                    return true;
                }
                Logger.Info("Membership Repository - ValidatePassword:Password is wrong.");
                return false;
            }
            catch (Exception e)
            {
                Logger.Error("Membership Repository - ValidatePassword:Error:"+e);
                return false;
            }
            
        }
    }
}
