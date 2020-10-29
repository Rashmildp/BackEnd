using System;
using System.Collections.Generic;

namespace SugestorBackend.Models
{
    public partial class TourGuide
    {
        public string GuideId { get; set; }
        public string UserId { get; set; }
        public string OtherDetails { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Languages { get; set; }
        public string PhonenNmber { get; set; }
        public decimal CostPerDay { get; set; }
        public string Comments { get; set; }
        public string Notifications { get; set; }

        public virtual Users User { get; set; }
    }
}
