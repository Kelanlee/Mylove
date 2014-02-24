using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;
using Data.Repository.Implement;
using DataContract;
using log4net;
using Servers.Interface;
using Data.Repository.Interface;

namespace Servers
{
    public class WishServers:IWishServers
    {
        private IWishRepository wishRepository;
        private IUserRepository userRepository;
        public ITrackingRepository trackingRepository;
        private ILog Logger;
        public WishServers()
        {
            Logger = LogManager.GetLogger(this.GetType());
            wishRepository=new WishRepository();
            userRepository=new UserRepository();
            trackingRepository=new TrackingRepository();
        }

        public bool MakeAWish(int userId, string wishText,string wishTitle)
        {
            try
            {
                if (userId==null||userId==0)
                {
                    return false;
                }
                Wish wish = new Wish() { UserId = userId, Wishcontent = wishText, WishStateId = 1 ,WishTitle = wishTitle,WishTime = DateTime.Now};
                

                var result=wishRepository.AddOrUpdateAWish(wish);
                if (result)
                {
                    trackingRepository.AddTracking(userId, 2, "许了一个愿望：" + wishTitle);
                }
                return result;

            }
            catch (Exception e)
            {
                Logger.Error("WishServers-MakeAWish:Error:"+e);
                throw;
            }
            

        }

        public List<WishData> GetLoverWishesList(int UserId)
        {
            try
            {
                if (UserId==null||UserId==0)
                {
                    return null;
                }
                var user = userRepository.getUserByUserId(UserId);
                int RelationId = (int)user.Relationship;
                var WishesList = wishRepository.GetTheWishes(RelationId);
                List<WishData> WishDatas = new List<WishData>();
                foreach (var wish in WishesList)
                {
                    WishDatas.Add(new WishData() { WishId = wish.id, Wishcontext = wish.Wishcontent, WishState = wish.WishStateId ,WishTitle = wish.WishTitle,WishTime = wish.WishTime,ApprovalTime = wish.ApprovalTime});
                }

                return WishDatas;
            }
            catch (Exception e)
            {
                Logger.Error("WishServers-GetLoverWishesList"+e);
                throw;
            }
            

        }

        public List<WishData> GetMyWishList(int UserId)
        {
            try
            {
                if (UserId == null || UserId == 0)
                {
                    return null;
                }
                
                var WishesList = wishRepository.GetTheWishes(UserId);
                List<WishData> WishDatas = new List<WishData>();
                foreach (var wish in WishesList)
                {
                    WishDatas.Add(new WishData() { WishId = wish.id, Wishcontext = wish.Wishcontent, WishState = wish.WishStateId, WishTitle = wish.WishTitle,WishTime = wish.WishTime, ApprovalTime = wish.ApprovalTime });
                }

                return WishDatas;
            }
            catch (Exception e)
            {
                Logger.Error("WishServers-GetLoverWishesList" + e);
                throw;
            }
        }


        public bool ApproveAWish(int wishId)
        {
            try
            {
                Wish wish = wishRepository.GetAWish(wishId);
                wish.WishStateId = 2;
                wish.ApprovalTime = DateTime.Now;

                var result=wishRepository.AddOrUpdateAWish(wish);

                if (result)
                {
                    trackingRepository.AddTracking((int) wish.User.Relationship, 2, "批准了一个愿望:" + wish.WishTitle);
                }
                return result;


            }
            catch (Exception e)
            {
                Logger.Error("WishServers-ApproveAWish" + e);
                throw;
            }
            

            
        }

        
    }
}
