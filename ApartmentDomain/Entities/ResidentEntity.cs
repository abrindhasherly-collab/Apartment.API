using ApartmentDomain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentDomain.Entities
{
    public class ResidentEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int FlatId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime DateOfJoining { get; set; }

        public ResidentStatus Status { get; set; }

    }
}
