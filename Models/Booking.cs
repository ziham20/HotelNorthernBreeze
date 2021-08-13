using System;
using System.Collections.Generic;

#nullable disable

namespace HotelNorthernBreeze.Models
{
    public partial class Booking
    {
        public string Category { get; set; }
        public string Size { get; set; }
        public string UserNic { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public virtual Room Room { get; set; }
        public virtual User UserNicNavigation { get; set; }
    }
}
