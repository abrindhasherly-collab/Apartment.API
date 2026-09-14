using ApartmentDomain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentDomain.Entities
{
    public class ComplaintEntity
    {
        public int Id { get; set; }

        public int ResidentId { get; set; }

        public int FlatId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime ComplaintDate { get; set; }

        public ComplaintStatus Status { get; set; }
    }
}
