using ApartmentDomain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentApplication.DTOs.Flat
{
    public class FlatResponseDto
    {
        public int Id { get; set; }

        public string FlatNumber { get; set; } = string.Empty;

        public int Floor { get; set; }

        public int BuildingId { get; set; }

        public string FlatType { get; set; } = string.Empty;

        public FlatStatus Status { get; set; }

        public int? ResidentId { get; set; }
    }
}
