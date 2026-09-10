using ApartmentDomain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApartmentApplication.DTOs.Flat
{
    public class FlatUpdateDto
    {
        [Required]
        [MaxLength(20)]
        public string FlatNumber { get; set; } = string.Empty;

        [Required]
        public int Floor { get; set; }

        [Required]
        public int BuildingId { get; set; }

        [Required]
        [MaxLength(20)]
        public string FlatType { get; set; } = string.Empty;

        [Required]
        public FlatStatus Status { get; set; }

        public int? ResidentId { get; set; }
    }
}
