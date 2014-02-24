using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using Data.Models;
using Data.Repository.Implement;
using Data.Repository.Interface;
using DataContract;
using Servers.Interface;
using log4net;
namespace Servers
{
    public class LoginServers:ILoginServers
    {
        public IUserRepository userRepository;
        public IMembershipRepository membershipRepository;
        public ITrackingRepository trackingRepository;
        public ILog Logger;
        public LoginServers()
        {
            Logger = LogManager.GetLogger(this.GetType());
            userRepository=new UserRepository();
            membershipRepository=new MembershipRepository();
            trackingRepository=new TrackingRepository();
        }

        public bool LoginAccount(List<DataElement> de, out int userId)
        {
            try
            {
                var username = de.FirstOrDefault(p => p.Name.ToLower() == "username").Value ?? "";
                var password = de.FirstOrDefault(p => p.Name.ToLower() == "password").Value ?? "";
                Logger.Info("LoginServers-LoginAccount:username="+username+" password="+password);
                var user = userRepository.getUserByUsername(username);

                if (!ValidateUser(user, out userId))
                {
                    Logger.Info("LoginServers-LoginAccount:can not find user" );

                    return false;
                }
                var result=membershipRepository.ValidatePassword(userId, password);

                if (result)
                {
                    trackingRepository.AddTracking(userId, 1, "登陆成功");
                }

                return result;
            }
            catch (Exception e)
            {
                Logger.Error("LoginServers-LoginAccount:Error:"+e);
                userId = 0;
                return false;
            }
        }

        public bool ValidateUser(User user,out int userId)
        {
            userId = 0;
            if (user==null)
            {
                return false;
            }
            userId = user.UserId;
            return true;
        }
    }
}
