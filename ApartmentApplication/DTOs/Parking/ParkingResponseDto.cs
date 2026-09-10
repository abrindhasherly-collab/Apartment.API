using ApartmentDomain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentApplication.DTOs.Parking
{
    public class ParkingResponseDto
    {
        public int Id { get; set; }

        public string SlotNumber { get; set; } = string.Empty;

        public string? VehicleNumber { get; set; }

        public int? FlatId { get; set; }

        public VehicleType? VehicleType { get; set; }

        public ParkingStatus Status { get; set; }
    }
}
