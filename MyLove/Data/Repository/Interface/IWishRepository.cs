using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;

namespace Data.Repository.Interface
{
    public interface IWishRepository
    {
        bool AddOrUpdateAWish(Wish wish);

        IList<Wish> GetTheWishes(int UserId);
        Wish GetAWish(int wishId);
    }
}
