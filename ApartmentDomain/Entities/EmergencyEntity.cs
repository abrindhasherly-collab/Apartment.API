using ApartmentDomain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentDomain.Entities
{
    public class EmergencyEntity
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

        public int FlatId { get; set; }

        public string EmergencyType { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public EmergencyPriority Priority { get; set; }

        public DateTime ReportedDate { get; set; }

        public EmergencyStatus Status { get; set; }
    }
}
