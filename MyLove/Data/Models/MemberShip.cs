using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class MemberShip
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public Nullable<int> WrongTime { get; set; }
        public virtual User User { get; set; }
    }
}
