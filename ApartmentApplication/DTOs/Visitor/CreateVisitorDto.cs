namespace ApartmentApplication.DTOs.Visitor
{
    public class CreateVisitorDto
    {
        public string VisitorName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string VehicleNumber { get; set; } = string.Empty;

        public int FlatId { get; set; }

        public string Purpose { get; set; } = string.Empty;

        public DateTime VisitDate { get; set; }

        public DateTime? CheckInTime { get; set; }

        public DateTime? CheckOutTime { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}