namespace ApartmentApplication.DTOs.FlatTransfer
{
    public class UpdateFlatTransferDto
    {
        public int FlatId { get; set; }

        public int FromResidentId { get; set; }

        public int ToResidentId { get; set; }

        public DateTime TransferDate { get; set; }

        public string Reason { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
    }
}