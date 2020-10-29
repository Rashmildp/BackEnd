using System;
using System.Collections.Generic;

namespace SugestorBackend.Models
{
    public partial class Users
    {
        public Users()
        {
            EventPlanner = new HashSet<EventPlanner>();
            Hotels = new HashSet<Hotels>();
            TourGuide = new HashSet<TourGuide>();
            TransportProvider = new HashSet<TransportProvider>();
        }

        public string UserId { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime? Dob { get; set; }
        public string HouseNo { get; set; }
        public string Lane { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }

        public virtual ICollection<EventPlanner> EventPlanner { get; set; }
        public virtual ICollection<Hotels> Hotels { get; set; }
        public virtual ICollection<TourGuide> TourGuide { get; set; }
        public virtual ICollection<TransportProvider> TransportProvider { get; set; }
    }
}
