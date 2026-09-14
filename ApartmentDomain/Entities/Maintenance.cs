using ApartmentDomain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentDomain.Entities
{
    public class Maintenance
    {
        public int Id { get; set; }

        public int FlatId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Month { get; set; }

        public DateTime DueDate { get; set; }

        public MaintenanceStatus Status { get; set; }
    }
}
