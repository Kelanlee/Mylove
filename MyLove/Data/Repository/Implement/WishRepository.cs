using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using Data.Models;
using Data.Repository.Interface;
using log4net;

namespace Data.Repository.Implement
{
    public class WishRepository : BaseRepository, IWishRepository
    {
        public WishRepository()
        {
            Logger = LogManager.GetLogger(this.GetType());
            DB=new MyLoveContext();
        }

        public bool AddOrUpdateAWish(Wish wish)
        {
            try
            {
                if (wish.UserId == null || wish.WishStateId ==null)
                {
                    return false;
                }
                DB.Wishs.AddOrUpdate(wish);
                DB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Logger.Error("WishRepository-AddOrUpdateAWish:Error:" + e);
                throw;
            }
        }

        public IList<Wish> GetTheWishes(int UserId)
        {
            try
            {
                return DB.Wishs.Where(p => p.UserId == UserId).ToList();
            }
            catch (Exception e)
            {
                Logger.Error("WishRepository-GetTheWishes:Error:"+e);
                throw;
            }
        }

        public Wish GetAWish(int wishId)
        {
            try
            {
                return DB.Wishs.FirstOrDefault(p => p.id == wishId);
            }
            catch (Exception e)
            {
                
                Logger.Error("WishRepository-GetAWish:Error:" + e);
                throw;
            }
        }
    }
}
