using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Models
{
    public partial class Location
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AddressName { get; set; }
        public virtual User User { get; set; }
    }
}
