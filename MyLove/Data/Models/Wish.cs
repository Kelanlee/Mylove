using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Wish
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public string Wishcontent { get; set; }
        public string WishTitle { get; set; }
        public int WishStateId { get; set; }
        public DateTime WishTime { get; set; }
        public DateTime ApprovalTime { get; set; }
        public virtual User User { get; set; }
        public virtual WishState WishState1 { get; set; }
    }
}
