using System;
using System.Collections.Generic;

namespace SugestorBackend.Models
{
    public partial class Hotels
    {
        public string HotelId { get; set; }
        public string UserId { get; set; }
        public string HotelName { get; set; }
        public string Features { get; set; }
        public string PhoneNumber { get; set; }
        public string District { get; set; }
        public string Venue { get; set; }
        public string OtherDetails { get; set; }
        public string Comments { get; set; }
        public string Notifications { get; set; }

        public virtual Users User { get; set; }
    }
}
