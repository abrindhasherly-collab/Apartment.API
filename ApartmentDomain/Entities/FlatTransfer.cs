using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentDomain.Entities
{
    public class FlatTransfer
    {
        public int Id { get; set; }

        public int FlatId { get; set; }

        public int FromResidentId { get; set; }

        public int ToResidentId { get; set; }

        public DateTime TransferDate { get; set; }

        public string Reason { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
    }
}
