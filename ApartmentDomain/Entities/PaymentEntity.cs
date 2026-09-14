using ApartmentDomain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentDomain.Entities
{
    public class PaymentEntity
    {
        public int Id { get; set; }

        public int? MaintenanceId { get; set; }

        public int FlatId { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public PaymentType PaymentType { get; set; }

        public PaymentStatus Status { get; set; }
    }
}
