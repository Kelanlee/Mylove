using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Tracking
    {
        public int id { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Tracking1 { get; set; }
        public int TrackingType { get; set; }
        public DateTime TrackingTime { get; set; }
        public virtual TrackingType TrackingType1 { get; set; }
        public virtual User User { get; set; }
    }
}
