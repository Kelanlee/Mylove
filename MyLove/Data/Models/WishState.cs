using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class WishState      
    {
        public WishState()
        {
            this.Wishes = new List<Wish>();
        }

        

        public int WishStateId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Wish> Wishes { get; set; }
    }
}
