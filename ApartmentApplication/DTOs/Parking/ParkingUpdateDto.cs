using ApartmentDomain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApartmentApplication.DTOs.Parking
{
    public class ParkingUpdateDto
    {
        [Required]
        [MaxLength(20)]
        public string SlotNumber { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? VehicleNumber { get; set; }

        public int? FlatId { get; set; }

        public VehicleType? VehicleType { get; set; }

        [Required]
        public ParkingStatus Status { get; set; }
    }
}
