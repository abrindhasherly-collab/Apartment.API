namespace ApartmentApplication.DTOs.ParcelDelivery
{
    public class ParcelDeliveryDto
    {
        public int Id { get; set; }

        public int FlatId { get; set; }

        public string DeliveryPersonName { get; set; } = string.Empty;

        public string DeliveryPersonPhone { get; set; } = string.Empty;

        public string TrackingNumber { get; set; } = string.Empty;

        public string DeliveryCompany { get; set; } = string.Empty;

        public DateTime DeliveryDate { get; set; }

        public DateTime? ReceivedTime { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}