using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class User
    {
        public User()
        {
            this.MemberShips = new List<MemberShip>();
            this.Trackings = new List<Tracking>();
            this.Users1 = new List<User>();
            this.Wishs = new List<Wish>();
            this.Locations = new List<Location>();

        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public string PhotoRef { get; set; }
        public Nullable<int> Relationship { get; set; }
        public virtual ICollection<MemberShip> MemberShips { get; set; }
        public virtual ICollection<Tracking> Trackings { get; set; }
        public virtual ICollection<User> Users1 { get; set; }
        public virtual User User1 { get; set; }
        public virtual ICollection<Wish> Wishs { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
