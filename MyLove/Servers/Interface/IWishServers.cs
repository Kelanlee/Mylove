using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataContract;

namespace Servers.Interface
{
    public interface IWishServers
    {
        bool MakeAWish(int UserId, string WishText, string wishTitle);

        List<WishData> GetLoverWishesList(int UserId );

        List<WishData> GetMyWishList(int UserId );

        bool ApproveAWish(int wishId);


    }
}
