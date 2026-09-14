using ApartmentDomain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentDomain.Entities
{
    public class Staff
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string JobRole { get; set; } = string.Empty;

        public DateTime JoiningDate { get; set; }

        public StaffStatus Status { get; set; }
    }
}
