using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class TrackingType
    {
        public TrackingType()
        {
            this.Trackings = new List<Tracking>();
        }

        public int TrackingTypeId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Tracking> Trackings { get; set; }
    }
}
