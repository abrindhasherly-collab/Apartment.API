using ApartmentDomain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApartmentApplication.DTOs.Maintenance
{
    public class MaintenanceUpdateDto
    {
        [Required]
        public int FlatId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Month { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public MaintenanceStatus Status { get; set; }
    }
}
