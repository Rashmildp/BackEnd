using System;
using System.Collections.Generic;

namespace SugestorBackend.Models
{
    public partial class TransportProvider
    {
        public string Tpid { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public decimal CostPerDistance { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string TypesOfVehicles { get; set; }
        public string Comments { get; set; }
        public string Notifications { get; set; }

        public virtual Users User { get; set; }
    }
}
