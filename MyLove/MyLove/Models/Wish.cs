using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLove.Models
{
    public class Wish
    {
        public int WishId { get; set; }
        public string WishTitle { get; set; }
        public string Wishcontext { get; set; }
        public int WishState { get; set; }
        public DateTime WishTime { get; set; }
        public DateTime ApprovalTime { get; set; }
    }
}